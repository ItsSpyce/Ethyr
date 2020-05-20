﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Logic
{
  public interface IBlockProvider
  {
    int Id { get; }
    CrosshairType Crosshair { get; }
    int Hardness { get; }

  }
}
