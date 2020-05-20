using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Forge
{
  public struct ItemDropConfig
  {
    public ItemType Item;
    public int MinCount;
    public int MaxCount;
    public float Probability;
    public float StickChance;
    public string ToolCategory;
    public string Tag;

    public ItemDropConfig(ItemType item, int min, int max, float probability, float stickChance, string toolCategory, string tag)
    {
      Item = item;
      MinCount = min;
      MaxCount = max;
      Probability = probability;
      StickChance = stickChance;
      ToolCategory = toolCategory;
      Tag = tag;
    }
  }
}
