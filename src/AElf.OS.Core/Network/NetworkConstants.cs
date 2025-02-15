namespace AElf.OS.Network
{
    public static class NetworkConstants
    {
        public const int DefaultPeerDialTimeoutInMilliSeconds = 3000;
        public const int DefaultPeerRecoveryTimeoutInMilliSeconds = 3000;
        public const bool DefaultCompressBlocks = true;
        public const int DefaultMaxRequestRetryCount = 1;
        public const int DefaultMaxPeers = 25;
        public const int DefaultMaxPeersPerIpAddress = 0;

        public const int DefaultSessionIdSize = 5;

        public const int DefaultMaxBlockAgeToBroadcastInMinutes = 10;

        public const int DefaultInitialSyncOffset = 512;

        public const int DefaultDiscoveryMaxNodesToRequest = 10;
        public const int DefaultDiscoveryPeriodInMilliSeconds = 60_000;
        public const int DefaultDiscoveryPeersToRequestCount = 5;

        public const string PeerReconnectionQueueName = "PeerReconnectionQueue";
        public const string AnnouncementBroadcastQueueName = "AnnouncementBroadcastQueue";
        public const string TransactionBroadcastQueueName = "TransactionBroadcastQueue";
        public const string BlockBroadcastQueueName = "BlockBroadcastQueue";

        public const long HandshakeTimeout = 1000;

        public const long PeerConnectionTimeout = 10000;

        public const int DefaultMaxBufferedTransactionCount = 100;
        public const int DefaultMaxBufferedBlockCount = 50;
        public const int DefaultMaxBufferedAnnouncementCount = 200;

        public const int DefaultPeerReconnectionPeriod = 60_000; // 1 min
    }
}