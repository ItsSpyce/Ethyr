using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public interface IThreadManager
  {
    ThreadInfo MainThread { get; }

    ThreadInfo CreateThread(string name, ParameterizedThreadStart start, ThreadPriority priority);

    ThreadInfo CreateBackgroundThread(string name, ParameterizedThreadStart start);

    TaskInfo QueueTask(Action action);

    TaskInfo QueueRepeatingTask(Action<int> action);
  }
}
