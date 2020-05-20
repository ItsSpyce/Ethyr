using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Forge
{
  public class BlockType
  {
    public enum BlockTags
    {
      NONE,
      GROWABLE,
      DOOR,
      WINDOW,
      TREE_TRUNK,
      GORE,
      SPIKE
    }

    public const int MAX_BLOCK_ID = 32767;

    private static Dictionary<string, BlockType> m_registeredBlocks = new Dictionary<string, BlockType>();

    public int Id { get; }
    public string Name { get; }
    public ItemDropConfig ItemDropConfig { get; }
    public BlockCollisionType BlockCollisionType { get; }
    public bool CanPickup { get; }
    public BlockTags Tags { get; }
    public bool CanMobsSpawnOn { get; }
    public bool CanPlayersSpawnOn { get; }
    public bool CanDecorateOnSlopes { get; }
    public bool IsTerrainDecoration { get; }
    public bool IsDecoration { get; }
    public bool IsDistantDecoration { get; }
  }
}
