using Ethyr.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Forge
{
  public interface IChunk
  {
    Vector2F Coordinates { get; }
    bool IsDirty { get; }

    BlockDescriptor GetBlock(int x, int y, int z);
    BlockDescriptor GetBlock(Vector3 coords);

    void SetBlock(int x, int y, int z, BlockDescriptor block);
    void SetBlock(Vector3 coords, Block block);
  }
}
