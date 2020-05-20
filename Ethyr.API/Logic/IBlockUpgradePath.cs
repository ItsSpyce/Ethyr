using Ethyr.API.Forge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Logic
{
  public interface IBlockUpgradePath
  {
    IBlockProvider From { get; }
    IBlockProvider To { get; }

    bool CanUpgrade(Block block);
    bool CanDowngrade(Block block);
  }
}
