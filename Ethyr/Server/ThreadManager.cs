using Ethyr.API;
using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethyr.Server
{
  public class ThreadManager : IThreadManager
  {
    private List<ThreadInfo> m_RunningThreads = new List<ThreadInfo>();
    private Queue<TaskInfo> m_QueuedTasks = new Queue<TaskInfo>();
    private long m_TimeElapsed = 0;
    private object m_TaskLock = new object();

    public ThreadInfo MainThread { get; }

    public ThreadManager(ThreadInfo mainThread)
    {
      MainThread = mainThread;
      m_RunningThreads.Add(mainThread);
      ThreadPool.SetMaxThreads(Environment.ProcessorCount * 2, Environment.ProcessorCount);
      CreateThread("Ethyr.TaskThread", state =>
      {

      }, ThreadPriority.Normal);
    }

    public ThreadInfo CreateThread(string name, ParameterizedThreadStart start, ThreadPriority priority)
    {
      var thread = new Thread(start)
      {
        Priority = priority,
        Name = name
      };
      return new ThreadInfo(thread);
    }

    public ThreadInfo CreateBackgroundThread(string name, ParameterizedThreadStart start)
    {
      var thread = new Thread(start)
      {
        IsBackground = true,
        Priority = ThreadPriority.BelowNormal,
        Name = name
      };
      return new ThreadInfo(thread);
    }

    public TaskInfo QueueTask(Action action)
    {
      var cancellationToken = new CancellationTokenSource();
      var task = new Task(action, cancellationToken.Token);
      var taskInfo = new TaskInfo(task, cancellationToken);
      lock (m_TaskLock)
      {
        m_QueuedTasks.Enqueue(taskInfo);
      }
      return taskInfo;
    }

    public TaskInfo QueueRepeatingTask(Action<int> action)
    {
      throw new NotImplementedException();
    }
  }
}
