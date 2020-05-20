using System.IO;

namespace Ethyr.API.Net
{
  public interface IPacket
  {
    byte Id { get; }
    PacketDirection Direction { get; }

    byte Channel { get; }
    bool ShouldCompress { get; }
    bool ShouldFlushQueue { get; }

    int GetLength();
    void ReadFrom(BinaryReader reader);
    void WriteTo(BinaryWriter writer);
  }
}