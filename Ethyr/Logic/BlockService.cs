using Ethyr.API.Logic;
using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Logic
{
  public sealed class BlockService : IBlockService
  {
    public IServer Server { get; }
    public string Name => "Ethyr.BlockService";
    public ThreadInfo ThreadInfo { get; }

    public BlockService(IServer server)
    {
      Server = server;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {
      Server.Logger.Debug("Initializing block service");
    }

    public void Update(long deltaTime)
    {

    }
  }
}
