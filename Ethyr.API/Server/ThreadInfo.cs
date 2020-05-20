using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public class ThreadInfo : ICancellable
  {
    public bool IsComplete { get; }
    public bool IsRunning { get; }
    public Thread Thread { get; }

    public ThreadInfo(Thread thread)
    {
      Thread = thread;
      if (thread.IsAlive)
      {
        IsRunning = true;
      }
    }

    public void Start()
    {
      Thread.Start();
    }

    public void Sleep(int ms)
    {
      Thread.Sleep(ms);
    }

    public void Wait()
    {
      Thread.Join();
    }

    public void Cancel(bool force)
    {
      if (force)
      {
        Thread.Abort();
      }
      else
      {
        Thread.Join();
      }
    }
  }
}
