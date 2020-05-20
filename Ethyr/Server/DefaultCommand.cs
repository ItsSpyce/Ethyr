using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr
{
  public sealed class DefaultCommand : Command
  {
    public override CommandExecutor Execute { get; }

    public DefaultCommand(string name, CommandExecutor execute) : base(name)
    {
      Execute = execute;
    }

    public DefaultCommand(string name, string permission, CommandExecutor execute) : base(name)
    {
      Permission = permission;
      Execute = execute;
    }
  }
}
