using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Forge
{
  public interface IMaterial
  {
    bool IsStabilitySupport { get; set; }
    float Resistance { get; set; }
    float Hardness { get; set; }
    bool IsCollidable { get; set; }
    int LightOpacity { get; set; }
    int StabilityGlue { get; set; }
    bool IsLiquid { get; set; }
    MaterialCategory DamageCategory { get; set; }
    MaterialCategory SurfaceCategory { get; set; }
    MaterialCategory ParticleCategory { get; set; }
    MaterialCategory ParticleDestroyCategory { get; set; }
    MaterialCategory ForgeCategory { get; set; }
    int FertileLevel { get; set; }
    bool IsPlant { get; set; }
    float MovementFactor { get; set; }
    float Friction { get; set; }
    int Mass { get; set; }
    int MaxDamage { get; set; }
    float Experience { get; set; }
    string Id { get; }
    bool IsGroundCover { get; set; }
  }
}
