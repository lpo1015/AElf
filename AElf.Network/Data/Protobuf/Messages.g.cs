// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: messages.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace AElf.Network.Data {

  /// <summary>Holder for reflection information generated from messages.proto</summary>
  public static partial class MessagesReflection {

    #region Descriptor
    /// <summary>File descriptor for messages.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MessagesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5tZXNzYWdlcy5wcm90byIrCghOb2RlRGF0YRIRCglJcEFkZHJlc3MYASAB",
            "KAkSDAoEUG9ydBgCIAEoBSIrCgxQZWVyTGlzdERhdGESGwoIbm9kZURhdGEY",
            "ASADKAsyCS5Ob2RlRGF0YSIjCg9SZXFQZWVyTGlzdERhdGESEAoIbnVtUGVl",
            "cnMYASABKAUiHgoMQmxvY2tSZXF1ZXN0Eg4KBkhlaWdodBgBIAEoBSIbCglU",
            "eFJlcXVlc3QSDgoGVHhIYXNoGAEgASgMIhwKCkhlaWdodERhdGESDgoGSGVp",
            "Z2h0GAEgASgFQhSqAhFBRWxmLk5ldHdvcmsuRGF0YWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Network.Data.NodeData), global::AElf.Network.Data.NodeData.Parser, new[]{ "IpAddress", "Port" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Network.Data.PeerListData), global::AElf.Network.Data.PeerListData.Parser, new[]{ "NodeData" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Network.Data.ReqPeerListData), global::AElf.Network.Data.ReqPeerListData.Parser, new[]{ "NumPeers" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Network.Data.BlockRequest), global::AElf.Network.Data.BlockRequest.Parser, new[]{ "Height" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Network.Data.TxRequest), global::AElf.Network.Data.TxRequest.Parser, new[]{ "TxHash" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Network.Data.HeightData), global::AElf.Network.Data.HeightData.Parser, new[]{ "Height" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NodeData : pb::IMessage<NodeData> {
    private static readonly pb::MessageParser<NodeData> _parser = new pb::MessageParser<NodeData>(() => new NodeData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NodeData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Network.Data.MessagesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeData(NodeData other) : this() {
      ipAddress_ = other.ipAddress_;
      port_ = other.port_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeData Clone() {
      return new NodeData(this);
    }

    /// <summary>Field number for the "IpAddress" field.</summary>
    public const int IpAddressFieldNumber = 1;
    private string ipAddress_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string IpAddress {
      get { return ipAddress_; }
      set {
        ipAddress_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Port" field.</summary>
    public const int PortFieldNumber = 2;
    private int port_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Port {
      get { return port_; }
      set {
        port_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NodeData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NodeData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IpAddress != other.IpAddress) return false;
      if (Port != other.Port) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (IpAddress.Length != 0) hash ^= IpAddress.GetHashCode();
      if (Port != 0) hash ^= Port.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (IpAddress.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(IpAddress);
      }
      if (Port != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Port);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (IpAddress.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(IpAddress);
      }
      if (Port != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Port);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NodeData other) {
      if (other == null) {
        return;
      }
      if (other.IpAddress.Length != 0) {
        IpAddress = other.IpAddress;
      }
      if (other.Port != 0) {
        Port = other.Port;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            IpAddress = input.ReadString();
            break;
          }
          case 16: {
            Port = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class PeerListData : pb::IMessage<PeerListData> {
    private static readonly pb::MessageParser<PeerListData> _parser = new pb::MessageParser<PeerListData>(() => new PeerListData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PeerListData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Network.Data.MessagesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PeerListData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PeerListData(PeerListData other) : this() {
      nodeData_ = other.nodeData_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PeerListData Clone() {
      return new PeerListData(this);
    }

    /// <summary>Field number for the "nodeData" field.</summary>
    public const int NodeDataFieldNumber = 1;
    private static readonly pb::FieldCodec<global::AElf.Network.Data.NodeData> _repeated_nodeData_codec
        = pb::FieldCodec.ForMessage(10, global::AElf.Network.Data.NodeData.Parser);
    private readonly pbc::RepeatedField<global::AElf.Network.Data.NodeData> nodeData_ = new pbc::RepeatedField<global::AElf.Network.Data.NodeData>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::AElf.Network.Data.NodeData> NodeData {
      get { return nodeData_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PeerListData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PeerListData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!nodeData_.Equals(other.nodeData_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= nodeData_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      nodeData_.WriteTo(output, _repeated_nodeData_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += nodeData_.CalculateSize(_repeated_nodeData_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PeerListData other) {
      if (other == null) {
        return;
      }
      nodeData_.Add(other.nodeData_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            nodeData_.AddEntriesFrom(input, _repeated_nodeData_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ReqPeerListData : pb::IMessage<ReqPeerListData> {
    private static readonly pb::MessageParser<ReqPeerListData> _parser = new pb::MessageParser<ReqPeerListData>(() => new ReqPeerListData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReqPeerListData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Network.Data.MessagesReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReqPeerListData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReqPeerListData(ReqPeerListData other) : this() {
      numPeers_ = other.numPeers_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReqPeerListData Clone() {
      return new ReqPeerListData(this);
    }

    /// <summary>Field number for the "numPeers" field.</summary>
    public const int NumPeersFieldNumber = 1;
    private int numPeers_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int NumPeers {
      get { return numPeers_; }
      set {
        numPeers_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReqPeerListData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReqPeerListData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NumPeers != other.NumPeers) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (NumPeers != 0) hash ^= NumPeers.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (NumPeers != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(NumPeers);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (NumPeers != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(NumPeers);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReqPeerListData other) {
      if (other == null) {
        return;
      }
      if (other.NumPeers != 0) {
        NumPeers = other.NumPeers;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            NumPeers = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class BlockRequest : pb::IMessage<BlockRequest> {
    private static readonly pb::MessageParser<BlockRequest> _parser = new pb::MessageParser<BlockRequest>(() => new BlockRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BlockRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Network.Data.MessagesReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockRequest(BlockRequest other) : this() {
      height_ = other.height_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BlockRequest Clone() {
      return new BlockRequest(this);
    }

    /// <summary>Field number for the "Height" field.</summary>
    public const int HeightFieldNumber = 1;
    private int height_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Height {
      get { return height_; }
      set {
        height_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BlockRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BlockRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Height != other.Height) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Height != 0) hash ^= Height.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Height != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Height);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Height != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Height);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BlockRequest other) {
      if (other == null) {
        return;
      }
      if (other.Height != 0) {
        Height = other.Height;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Height = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class TxRequest : pb::IMessage<TxRequest> {
    private static readonly pb::MessageParser<TxRequest> _parser = new pb::MessageParser<TxRequest>(() => new TxRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TxRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Network.Data.MessagesReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TxRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TxRequest(TxRequest other) : this() {
      txHash_ = other.txHash_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TxRequest Clone() {
      return new TxRequest(this);
    }

    /// <summary>Field number for the "TxHash" field.</summary>
    public const int TxHashFieldNumber = 1;
    private pb::ByteString txHash_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString TxHash {
      get { return txHash_; }
      set {
        txHash_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TxRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TxRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TxHash != other.TxHash) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (TxHash.Length != 0) hash ^= TxHash.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (TxHash.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(TxHash);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (TxHash.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(TxHash);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TxRequest other) {
      if (other == null) {
        return;
      }
      if (other.TxHash.Length != 0) {
        TxHash = other.TxHash;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            TxHash = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class HeightData : pb::IMessage<HeightData> {
    private static readonly pb::MessageParser<HeightData> _parser = new pb::MessageParser<HeightData>(() => new HeightData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HeightData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Network.Data.MessagesReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HeightData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HeightData(HeightData other) : this() {
      height_ = other.height_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HeightData Clone() {
      return new HeightData(this);
    }

    /// <summary>Field number for the "Height" field.</summary>
    public const int HeightFieldNumber = 1;
    private int height_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Height {
      get { return height_; }
      set {
        height_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HeightData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HeightData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Height != other.Height) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Height != 0) hash ^= Height.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Height != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Height);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Height != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Height);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HeightData other) {
      if (other == null) {
        return;
      }
      if (other.Height != 0) {
        Height = other.Height;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Height = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
