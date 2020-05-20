using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Net
{
  public interface IGameStream
  {
    Stream BaseStream { get; }

    byte ReadUInt8();
    sbyte ReadInt8();
    void WriteUInt8(byte value);
    void WriteInt8(sbyte value);

    ushort ReadUInt16();
    short ReadInt16();
    void WriteUInt16(ushort value);
    void WriteInt16(short value);

    uint ReadUInt32();
    int ReadInt32();
    void WriteUInt32(uint value);
    void WriteInt32(int value);

    ulong ReadUInt64();
    long ReadInt64();
    void WriteUInt64(ulong value);
    void WriteInt64(long value);

    float ReadFloat();
    void WriteFloat(float value);

    double ReadDouble();
    void WriteDouble(double value);

    string ReadString();
    void WriteString(string value);

    bool ReadBool();
    void WriteBool(bool value);
  }
}
