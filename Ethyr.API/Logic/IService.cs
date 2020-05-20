using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Logic
{
  public interface IService : IDisposable
  {
    IServer Server { get; }
    string Name { get; }

    void Initialize();

    void Update(long deltaTime);
  }
}
