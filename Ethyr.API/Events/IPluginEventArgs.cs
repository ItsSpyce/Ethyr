using Ethyr.API.Nacht;
using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Events
{
  public interface IPluginEventArgs
  {
    IDynamicSource Origin { get; }
    IServer Server { get; }
  }
}
