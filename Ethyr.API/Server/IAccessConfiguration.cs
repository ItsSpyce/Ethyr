using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public interface IAccessConfiguration
  {
    AccessRestriction Restriction { get; }

  }
}
