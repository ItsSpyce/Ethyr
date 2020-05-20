using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Net
{
  public static class NetHelpers
  {
    public static byte ReadByte(Stream stream)
    {
      return (byte)stream.ReadByte();
    }

    public static byte ReadByte(byte[] buffer, int offset)
    {
      return buffer[offset];
    }

    public static short ReadShort(Stream stream)
    {
      return 0;
    }

    public static ushort ReadUShort(Stream stream)
    {
      return 0;
    }

    public static float ReadFloat(Stream stream)
    {
      return 0f;
    }

    public static double ReadDouble(Stream stream)
    {
      return 0d;
    }

    public static int ReadInt(Stream stream)
    {
      return 0 | (stream.ReadByte() & 0xFF) |
                ((stream.ReadByte() & 0xFF) << 8) |
                ((stream.ReadByte() & 0xFF) << 16) |
                ((stream.ReadByte() & 0xFF) << 24);
    }

    public static uint ReadUInt(Stream stream)
    {
      return 0;
    }

    public static long ReadLong(Stream stream)
    {
      return ((long)stream.ReadByte() & 0xFF) |
             ((long)(stream.ReadByte() & 0xFF) << 8) |
             ((long)(stream.ReadByte() & 0xFF) << 16) |
             ((long)(stream.ReadByte() & 0xFF) << 24) |
             ((long)(stream.ReadByte() & 0xFF) << 32) |
             ((long)(stream.ReadByte() & 0xFF) << 40) |
             ((long)(stream.ReadByte() & 0xFF) << 48) |
             ((long)(stream.ReadByte() & 0xFF) << 56);
    }

    public static ulong ReadULong(Stream stream)
    {
      return ((ulong)stream.ReadByte() & 0xFF) |
             ((ulong)(stream.ReadByte() & 0xFF) << 8) |
             ((ulong)(stream.ReadByte() & 0xFF) << 16) |
             ((ulong)(stream.ReadByte() & 0xFF) << 24) |
             ((ulong)(stream.ReadByte() & 0xFF) << 32) |
             ((ulong)(stream.ReadByte() & 0xFF) << 40) |
             ((ulong)(stream.ReadByte() & 0xFF) << 48) |
             ((ulong)(stream.ReadByte() & 0xFF) << 56);
    }

    public static string ReadString(Stream stream)
    {
      return "";
    }
  }
}
