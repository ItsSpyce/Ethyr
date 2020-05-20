using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Quest
{
  public interface IQuestReport
  {
    Guid QuesterId { get; }
    Guid QuestId { get; }
    int[] CompletionStatus { get; }
  }
}
