using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public class TaskInfo : ICancellable
  {
    public int Id => m_Task.Id;
    public object State => m_Task.AsyncState;
    public int Delay { get; set; }
    public bool IsCanceled { get; internal set; }

    private readonly Task m_Task;
    private readonly CancellationTokenSource m_CancelToken;
    
    public TaskInfo(Task task, CancellationTokenSource cancelToken)
    {
      m_Task = task;
      m_CancelToken = cancelToken;
      
    }

    public void Cancel(bool force)
    {
      if (m_Task.IsCompleted) 
        throw new InvalidOperationException("Cannot cancel completed tasks");
      if (m_CancelToken.IsCancellationRequested || IsCanceled) 
        throw new InvalidOperationException("The task has already been scheduled for cancellation");
      lock (m_CancelToken)
      {
        if (force)
        {
          m_CancelToken.Token.ThrowIfCancellationRequested();
          m_CancelToken.Cancel(true);
        }
        else
        {
          m_CancelToken.Cancel();
        }
        IsCanceled = true;
      }
    }

    public void Cancel(int after)
    {
      if (m_Task.IsCompleted)
        throw new InvalidOperationException("Cannot cancel completed tasks");
      if (m_CancelToken.IsCancellationRequested || IsCanceled)
        throw new InvalidOperationException("The task has already been scheduled for cancellation");
      lock (m_CancelToken)
      {
        m_CancelToken.CancelAfter(after);
      }
      IsCanceled = true;
    }
  }
}
