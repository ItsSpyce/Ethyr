using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Quest
{
  public interface IQuest
  {
    string Name { get; }
    Guid Id { get; }
  }
}
