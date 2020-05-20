using Ethyr.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public interface IServer
  {
    int Port { get; }
    bool IsRunning { get; }
    bool IsDebugMode { get; }
    IServerConfiguration Config { get; }
    IThreadManager ThreadManager { get; }
    ICommandManager CommandManager { get; }
    ILogger Logger { get; }

    void Start();
    void Stop();

    void OnServerStarted(object sender, IServerEventArgs eventArgs);

    void OnServerStopped(object sender, IServerEventArgs eventArgs);

    void OnServerTick(object sender, IServerEventArgs eventArgs);
  }
}
