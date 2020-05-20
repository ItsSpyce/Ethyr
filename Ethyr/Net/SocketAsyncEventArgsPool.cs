using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Net
{
  public sealed class SocketAsyncEventArgsPool : IDisposable
  {
    private readonly BlockingCollection<SocketAsyncEventArgs> m_ArgsPool;
    private readonly int m_MaxSize;
    private BufferManager m_BufferManager;
    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: dispose managed state (managed objects).
        }
        disposedValue = true;
      }
    }

    ~SocketAsyncEventArgsPool()
    {
      Dispose(false);
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
