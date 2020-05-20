using Ethyr.API.Quest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Server
{
  public interface IPlayer : IQuestable
  {
    Guid Id { get; }
    string Username { get; }
    string DisplayName { get; set; }
    int Level { get; set; }
    long Xp { get; set; }

  }
}
