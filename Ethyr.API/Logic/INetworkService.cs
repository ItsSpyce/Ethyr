using Ethyr.API.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Logic
{
  public interface INetworkService : IService
  {
    INetServer NetServer { get; }
  }
}
