using Ethyr.API.Logic;
using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Logic
{
  public class EntityService : IEntityService
  {
    public IServer Server { get; }
    public string Name => "Ethyr.EntityService";
    public ThreadInfo ThreadInfo { get; }

    public EntityService(IServer server)
    {
      Server = server;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {
      Server.Logger.Debug("Initializing entity service");
    }

    public void Update(long deltaTime)
    {

    }
  }
}
