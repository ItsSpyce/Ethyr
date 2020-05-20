using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Server
{
  public interface IPlayerManager
  {
    IPlayer GetPlayer(Guid id);
    void RemovePlayer(Guid id);
    void AddPlayer(Guid id);
  }
}
