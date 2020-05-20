using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public interface ICommandManager
  {
    bool TryGetCommand(string name, out Command command);
    bool RegisterCommand<TCommand>() where TCommand : Command;
    bool RegisterCommand(string name, CommandExecutor executor);
    bool RegisterCommand(string name, string permission, CommandExecutor executor);
    bool UnregisterCommand<TCommand>() where TCommand : Command;
    bool UnregisterCommand(string name);
  }
}
