using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.Helper;
using AElf.Kernel.TransactionPool.Infrastructure;
using AElf.OS.Network.Application;
using AElf.OS.Network.Events;
using AElf.OS.Network.Extensions;
using AElf.Types;
using Grpc.Core;
using Grpc.Core.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Volo.Abp.EventBus.Local;

namespace AElf.OS.Network.Grpc
{
    /// <summary>
    /// Implementation of the grpc generated service. It contains the rpc methods
    /// exposed to peers.
    /// </summary>
    public class GrpcServerService : PeerService.PeerServiceBase
    {
        private NetworkOptions NetworkOptions => NetworkOptionsSnapshot.Value;
        public IOptionsSnapshot<NetworkOptions> NetworkOptionsSnapshot { get; set; }

        private readonly ISyncStateService _syncStateService;
        private readonly IBlockchainService _blockchainService;
        private readonly IPeerDiscoveryService _peerDiscoveryService;
        private readonly IConnectionService _connectionService;

        public ILocalEventBus EventBus { get; set; }
        public ILogger<GrpcServerService> Logger { get; set; }

        public GrpcServerService(ISyncStateService syncStateService, IConnectionService connectionService,
            IBlockchainService blockchainService, IPeerDiscoveryService peerDiscoveryService)
        {
            _syncStateService = syncStateService;
            _connectionService = connectionService;
            _blockchainService = blockchainService;
            _peerDiscoveryService = peerDiscoveryService;

            EventBus = NullLocalEventBus.Instance;
            Logger = NullLogger<GrpcServerService>.Instance;
        }

        public override async Task<HandshakeReply> DoHandshake(HandshakeRequest request, ServerCallContext context)
        {
            try
            {
                Logger.LogDebug($"Peer {context.Peer} has requested a handshake.");
            
                if(!UriHelper.TryParsePrefixedEndpoint(context.Peer, out IPEndPoint peerEndpoint))
                    return new HandshakeReply { Error = HandshakeError.InvalidConnection};
            
                return await _connectionService.DoHandshakeAsync(peerEndpoint, request.Handshake);
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Handshake failed - {context.Peer}: ");
                throw;
            }
        }

        public override async Task<VoidReply> ConfirmHandshake(ConfirmHandshakeRequest request,
            ServerCallContext context)
        {
            try
            {
                Logger.LogDebug($"Peer {context.GetPeerInfo()} has requested a confirm handshake.");

                _connectionService.ConfirmHandshake(context.GetPublicKey());
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Confirm handshake error - {context.GetPeerInfo()}: ");
                throw;
            }

            return new VoidReply();
        }

        public override async Task<VoidReply> BlockBroadcastStream(
            IAsyncStreamReader<BlockWithTransactions> requestStream, ServerCallContext context)
        {
            Logger.LogDebug($"Block stream started with {context.GetPeerInfo()} - {context.Peer}.");
            
            try
            {
                await requestStream.ForEachAsync(r =>
                {
                    _ = EventBus.PublishAsync(new BlockReceivedEvent(r, context.GetPublicKey()));
                    return Task.CompletedTask;
                });
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Block stream error - {context.GetPeerInfo()}: ");
                throw;
            }
            
            Logger.LogDebug($"Block stream finished with {context.GetPeerInfo()} - {context.Peer}.");

            return new VoidReply();
        }

        public override async Task<VoidReply> AnnouncementBroadcastStream(
            IAsyncStreamReader<BlockAnnouncement> requestStream, ServerCallContext context)
        {
            Logger.LogDebug($"Announcement stream started with {context.GetPeerInfo()} - {context.Peer}.");

            try
            {
                await requestStream.ForEachAsync(async r => await ProcessAnnouncement(r, context));
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Announcement stream error: {context.GetPeerInfo()}");
                throw;
            }

            Logger.LogDebug($"Announcement stream finished with {context.GetPeerInfo()} - {context.Peer}.");

            return new VoidReply();
        }

        public Task ProcessAnnouncement(BlockAnnouncement announcement, ServerCallContext context)
        {
            if (announcement?.BlockHash == null)
            {
                Logger.LogError($"Received null announcement or header from {context.GetPeerInfo()}.");
                return Task.CompletedTask;
            }

            Logger.LogDebug($"Received announce {announcement.BlockHash} from {context.GetPeerInfo()}.");

            var peer = _connectionService.GetPeerByPubkey(context.GetPublicKey());

            if (peer != null)
            {
                peer.AddKnowBlock(announcement);

                _ = EventBus.PublishAsync(new AnnouncementReceivedEventData(announcement, context.GetPublicKey()));
            }

            return Task.CompletedTask;
        }

        public override async Task<VoidReply> TransactionBroadcastStream(IAsyncStreamReader<Transaction> requestStream,
            ServerCallContext context)
        {
            Logger.LogDebug($"Transaction stream started with {context.GetPeerInfo()} - {context.Peer}.");

            try
            {
                await requestStream.ForEachAsync(async tx => await ProcessTransaction(tx, context));
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Transaction stream error - {context.GetPeerInfo()}: ");
                throw;
            }

            Logger.LogDebug($"Transaction stream finished with {context.GetPeerInfo()} - {context.Peer}.");

            return new VoidReply();
        }

        /// <summary>
        /// This method is called when another peer broadcasts a transaction.
        /// </summary>
        public override async Task<VoidReply> SendTransaction(Transaction tx, ServerCallContext context)
        {
            try
            {
                await ProcessTransaction(tx, context);
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"SendTransaction error - {context.GetPeerInfo()}: ");
                throw;
            }

            return new VoidReply();
        }

        private async Task ProcessTransaction(Transaction tx, ServerCallContext context)
        {
            var chain = await _blockchainService.GetChainAsync();

            // if this transaction's ref block is a lot higher than our chain 
            // then don't participate in p2p network
            if (tx.RefBlockNumber > chain.LongestChainHeight + NetworkConstants.DefaultInitialSyncOffset)
                return;

            _ = EventBus.PublishAsync(new TransactionsReceivedEvent {Transactions = new List<Transaction> {tx}});
        }
        
        public override async Task<VoidReply> LibAnnouncementBroadcastStream(IAsyncStreamReader<LibAnnouncement> requestStream, ServerCallContext context)
        {
            Logger.LogDebug($"Lib announcement stream started with {context.GetPeerInfo()} - {context.Peer}.");
            
            try
            {
                await requestStream.ForEachAsync(async r => await ProcessLibAnnouncement(r, context));
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Lib announcement stream error: {context.GetPeerInfo()}");
                throw;
            }

            Logger.LogDebug($"Lib announcement stream finished with {context.GetPeerInfo()} - {context.Peer}.");

            return new VoidReply();
        }

        public Task ProcessLibAnnouncement(LibAnnouncement announcement, ServerCallContext context)
        {
            if (announcement?.LibHash == null)
            {
                Logger.LogError($"Received null or empty announcement from {context.GetPeerInfo()}.");
                return Task.CompletedTask;
            }
        
            Logger.LogDebug($"Received lib announce hash: {announcement.LibHash}, height {announcement.LibHeight} from {context.GetPeerInfo()}.");

            var peer = _connectionService.GetPeerByPubkey(context.GetPublicKey());
            peer?.UpdateLastKnownLib(announcement);
            
            return Task.CompletedTask;
        }

        /// <summary>
        /// This method is called when a peer wants to broadcast an announcement.
        /// </summary>
        public override async Task<VoidReply> SendAnnouncement(BlockAnnouncement an, ServerCallContext context)
        {
            try
            {
                await ProcessAnnouncement(an, context);
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Process announcement error: {context.GetPeerInfo()}");
                throw;
            }

            return new VoidReply();
        }

        /// <summary>
        /// This method returns a block. The parameter is a <see cref="BlockRequest"/> object, if the value
        /// of <see cref="BlockRequest.Hash"/> is not null, the request is by ID, otherwise it will be
        /// by height.
        /// </summary>
        public override async Task<BlockReply> RequestBlock(BlockRequest request, ServerCallContext context)
        {
            if (request == null || request.Hash == null || _syncStateService.SyncState != SyncState.Finished)
                return new BlockReply();

            Logger.LogDebug($"Peer {context.GetPeerInfo()} requested block {request.Hash}.");

            BlockWithTransactions block;
            try
            {
                block = await _blockchainService.GetBlockWithTransactionsByHash(request.Hash);

                if (block == null)
                    Logger.LogDebug($"Could not find block {request.Hash} for {context.GetPeerInfo()}.");
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Request block error: {context.GetPeerInfo()}");
                throw;
            }

            return new BlockReply {Block = block};
        }

        public override async Task<BlockList> RequestBlocks(BlocksRequest request, ServerCallContext context)
        {
            if (request == null ||
                request.PreviousBlockHash == null ||
                _syncStateService.SyncState != SyncState.Finished ||
                request.Count == 0 ||
                request.Count > GrpcConstants.MaxSendBlockCountLimit)
            {
                return new BlockList();
            }

            Logger.LogDebug(
                $"Peer {context.GetPeerInfo()} requested {request.Count} blocks from {request.PreviousBlockHash}.");

            var blockList = new BlockList();

            try
            {
                var blocks = await _blockchainService.GetBlocksWithTransactions(request.PreviousBlockHash, request.Count);

                if (blocks == null)
                    return blockList;

                blockList.Blocks.AddRange(blocks);

                if (NetworkOptions.CompressBlocksOnRequest)
                {
                    var headers = new Metadata
                        {new Metadata.Entry(GrpcConstants.GrpcRequestCompressKey, GrpcConstants.GrpcGzipConst)};
                    await context.WriteResponseHeadersAsync(headers);
                }
                
                Logger.LogTrace($"Replied to {context.GetPeerInfo()} with {blockList.Blocks.Count}, request was {request}");
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Request blocks error - {context.GetPeerInfo()} - request {request}: ");
                throw;
            }

            return blockList;
        }

        public override async Task<NodeList> GetNodes(NodesRequest request, ServerCallContext context)
        {
            if (request == null)
                return new NodeList();

            Logger.LogDebug($"Peer {context.GetPeerInfo()} requested {request.MaxCount} nodes.");

            NodeList nodes;
            try
            {
                nodes = await _peerDiscoveryService.GetNodesAsync(request.MaxCount);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Get nodes error: ");
                throw;
            }

            Logger.LogDebug($"Sending {nodes.Nodes.Count} to {context.GetPeerInfo()}.");

            return nodes;
        }

        public override Task<PongReply> Ping(PingRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PongReply());
        }

        /// <summary>
        /// Clients should call this method to disconnect explicitly.
        /// </summary>
        public override Task<VoidReply> Disconnect(DisconnectReason request, ServerCallContext context)
        {
            Logger.LogDebug($"Peer {context.GetPeerInfo()} has sent a disconnect request.");

            try
            {
                _connectionService.RemovePeer(context.GetPublicKey());
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Disconnect error: ");
                throw;
            }

            return Task.FromResult(new VoidReply());
        }
    }
}