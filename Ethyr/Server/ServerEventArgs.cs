using Ethyr.API.Events;
using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Server
{
  public class ServerEventArgs : IServerEventArgs
  {
    public IServer Server { get; }

    public ServerEventArgs(IServer server)
    {
      Server = server;
    }
  }
}
