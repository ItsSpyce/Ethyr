using Ethyr.API.Net;
using Ethyr.API.Server;
using Ethyr.Net.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethyr.Net
{
  public class NetServer : INetServer
  {
    private Dictionary<Guid, INetClient> m_ConnectedClients = new Dictionary<Guid, INetClient>();
    private IServer m_Server;
    private ThreadInfo m_NetworkThread;

    public int ConnectionCount => m_ConnectedClients.Count;
    public IPEndPoint EndPoint { get; }

    public event EventHandler<ConnectionRequestedEventArgs> ConnectionRequested;

    public ConnectionType ConnectionType => ConnectionType.Server;

    public NetServer(IServer server)
    {
      m_Server = server;
      EndPoint = new IPEndPoint(IPAddress.Loopback, server.Port);
      m_NetworkThread = m_Server.ThreadManager.CreateThread("Ethyr.NetworkServer", ExecuteNetworkThread, ThreadPriority.Normal);
    }

    private void ExecuteNetworkThread(object state)
    {
      while (m_Server.IsRunning)
      {

      }
    }

    public INetClient GetClient(Guid id)
    {
      return m_ConnectedClients[id];
    }

    public bool SendPacket<TPacket>(INetClient client, TPacket packet) where TPacket : IPacket
    {
      throw new NotImplementedException();
    }

    public void Start()
    {
      throw new NotImplementedException();
    }

    public void Stop()
    {
      throw new NotImplementedException();
    }

    public void OnConnectionRequested(object sender, ConnectionRequestedEventArgs eventArgs)
    {
      ConnectionRequested?.Invoke(sender, eventArgs);
    }
  }
}
