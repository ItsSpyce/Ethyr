using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public delegate void CommandExecutor(IEnumerable<string> args);

  public abstract class Command
  {
    public abstract CommandExecutor Execute { get; }

    public string Name { get; }
    public string Permission { get; set; }

    protected Command(string name)
    {
      Name = name;
    }
  }
}
