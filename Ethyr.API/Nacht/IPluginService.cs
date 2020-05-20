using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Nacht
{
  public interface IPluginService
  {
    IDynamicSource GetPlugin(string name);
    bool LoadPlugin(string location);
    bool LoadPlugin(Assembly assembly);
    bool UnloadPlugin(string name);
  }
}
