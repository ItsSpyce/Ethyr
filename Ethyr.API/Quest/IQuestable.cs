using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Quest
{
  public interface IQuestable
  {
    IQuestReport ActiveQuest { get; set; }
    void AssignQuest();
    void CancelQuest();
  }
}
