using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Net
{
  public class BufferManager
  {
    private readonly object m_Lock = new object();
    private readonly List<byte[]> m_Buffers;
    private readonly int m_BufferSize;
    private readonly Stack<int> m_AvailableBuffers;

    public BufferManager(int bufferSize)
    {
      m_BufferSize = bufferSize;
      m_Buffers = new List<byte[]>();
      m_AvailableBuffers = new Stack<int>();
    }

    public void SetBuffer(SocketAsyncEventArgs args)
    {
      byte[] buffer;
      if (m_AvailableBuffers.Count > 0)
      {
        var index = m_AvailableBuffers.Pop();
        lock (m_Lock)
        {
          buffer = m_Buffers[index];
        }
      }
      else
      {
        buffer = new byte[m_BufferSize];
        lock (m_Lock)
        {
          m_Buffers.Add(buffer);
        }
      }
      args.SetBuffer(buffer, 0, buffer.Length);
    }

    public void ClearBuffer(SocketAsyncEventArgs args)
    {
      int index;
      lock (m_Lock)
      {
        index = m_Buffers.IndexOf(args.Buffer);
      }

      if (index >= 0) m_AvailableBuffers.Push(index);

      args.SetBuffer(null, 0, 0);
    }
  }
}
