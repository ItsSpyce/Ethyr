using Ethyr.API.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Net.Packets
{
  public struct DisconnectPacket : IPacket
  {
    public byte Id => (byte)PacketType.PlayerDisconnect;

    public PacketDirection Direction => PacketDirection.Both;

    public byte Channel => 0;

    public bool ShouldCompress => false;

    public bool ShouldFlushQueue => true;

    public string Reason;

    public DisconnectPacket(string reason)
    {
      Debug.Assert(reason != null);
      Reason = reason;
    }

    public int GetLength()
    {
      return 4 + Reason.Length; // encoding?
    }

    public void ReadFrom(BinaryReader reader)
    {
      Reason = reader.ReadString();
    }

    public void WriteTo(BinaryWriter writer)
    {
      writer.Write(Reason);
    }
  }
}
