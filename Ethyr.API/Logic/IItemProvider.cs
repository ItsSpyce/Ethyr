using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Logic
{
  public interface IItemProvider
  {
    short Id { get; }
    ushort MaximumStack { get; }
    string DisplayName { get; }


  }
}
