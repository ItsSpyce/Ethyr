using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Forge
{
  public enum BlockFace : byte
  {
    TOP = 1,
    BOTTOM = 2,
    NORTH = 4,
    WEST = 8,
    SOUTH = 16,
    EAST = 32,
    ORDINAL = 63,
    ALL = 255
  }
}
