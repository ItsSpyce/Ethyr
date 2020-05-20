using Ethyr.API;
using Ethyr.API.Events;
using Ethyr.API.Logic;
using Ethyr.API.Server;
using Ethyr.Logic;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace Ethyr.Server
{
  public class MultiplayerServer : Singleton<MultiplayerServer>, IServer
  {
    public static ServerBuilder Builder => new ServerBuilder();

    private const int TICK_RATE = 1000 / 144;

    public int Port => Config.Port;
    public bool IsRunning { get; private set; } = false;
    public bool IsDebugMode { get; }

    public IServerConfiguration Config { get; private set; }
    public IThreadManager ThreadManager { get; }

    public ICommandManager CommandManager { get; }
    public ILogger Logger { get; }

    public event EventHandler<ServerEventArgs> ServerStarted;
    public event EventHandler<ServerEventArgs> ServerStopped;
    public event EventHandler<ServerEventArgs> ServerTick;

    private readonly ThreadInfo m_GameThread;

    private readonly IEntityService m_EntityService;
    private readonly INetworkService m_NetworkService;
    private readonly IBlockService m_BlockService;

    internal string ConfigFile = "config.json";

    internal MultiplayerServer(ILogger logger, IServerConfiguration config, bool isDebugMode)
    {
      IsDebugMode = isDebugMode;
      Thread.CurrentThread.Name = "Ethyr.Server";
      Logger = logger;
      Config = config;
      if (Port > short.MaxValue || Port < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(Port), $"Port must be positive and less than {short.MaxValue}");
      }

      m_GameThread = new ThreadInfo(new Thread(ExecuteMainThread));
      ThreadManager = new ThreadManager(m_GameThread);

      CommandManager = new CommandManager();

      m_EntityService = new EntityService(this);
      m_NetworkService = new NetworkService(this);
      m_BlockService = new BlockService(this);
    }

    private void ExecuteMainThread()
    {
      var deltaTime = 0L;
      while (IsRunning)
      {
        DateTime start = DateTime.Now;
        Update(deltaTime);
        DateTime end = DateTime.Now;
        var elapsed = (end - start).TotalMilliseconds;
        var sleep = Math.Max((int)(TICK_RATE - elapsed), 5);
        Thread.Sleep(sleep);
        deltaTime += sleep;
      }
    }

    public void Start()
    {
      IsRunning = true;
      m_GameThread.Start();
      m_BlockService.Initialize();
      m_EntityService.Initialize();
      m_NetworkService.Initialize();
    }

    public void Stop()
    {
      IsRunning = false;
      m_GameThread.Wait();
    }

    public void Update(long deltaTime)
    {
      OnServerTick(this, new ServerEventArgs(this));
    }

    public override void Dispose()
    {
      m_GameThread?.Wait();
      m_BlockService.Dispose();
      m_EntityService.Dispose();
      m_NetworkService.Dispose();
    }

    public void OnServerStarted(object sender, IServerEventArgs eventArgs)
    {
      ServerStarted?.Invoke(sender, eventArgs as ServerEventArgs);
    }

    public void OnServerStopped(object sender, IServerEventArgs eventArgs)
    {
      ServerStopped?.Invoke(sender, eventArgs as ServerEventArgs);
    }

    public void OnServerTick(object sender, IServerEventArgs eventArgs)
    {
      ServerTick?.Invoke(sender, eventArgs as ServerEventArgs);
    }
  }
}
