using Ethyr.API.Logic;
using Ethyr.API.Net;
using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Logic
{
  public class NetworkService : INetworkService
  {
    public IServer Server { get; }
    public string Name => "Ethyr.NetworkService";
    public INetServer NetServer { get; }

    public NetworkService(IServer server)
    {
      Server = server;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {
      Server.Logger.Debug("Initializing network service");
    }

    public void Update(long deltaTime)
    {

    }
  }
}
