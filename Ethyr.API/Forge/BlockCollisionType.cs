using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Forge
{
  public enum BlockCollisionType
  {
    Sight = 1,
    Movement = 2,
    Bullets = 4,
    Rockets = 8,
    Melee = 16,
    Arrows = 32
  }
}
