using Ethyr.API.Forge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Forge
{
    public class Material : IMaterial
    {
        public bool IsStabilitySupport { get; set; }
        public float Resistance { get; set; }
        public float Hardness { get; set; }
        public bool IsCollidable { get; set; }
        public int LightOpacity{ get; set; }
        public int StabilityGlue{ get; set; }
        public bool IsLiquid{ get; set; }
        public MaterialCategory DamageCategory{ get; set; }
        public MaterialCategory SurfaceCategory{ get; set; }
        public MaterialCategory ParticleCategory{ get; set; }
        public MaterialCategory ParticleDestroyCategory{ get; set; }
        public MaterialCategory ForgeCategory{ get; set; }
        public int FertileLevel{ get; set; }
        public bool IsPlant{ get; set; }
        public float MovementFactor{ get; set; }
        public float Friction{ get; set; }
        public int Mass{ get; set; }
        public int MaxDamage{ get; set; }
        public float Experience{ get; set; }

        public string Id { get; }

        public bool IsGroundCover{ get; set; }

        public static Dictionary<string, Material> RegisteredMaterials = new Dictionary<string, Material>();
        public static Material Air = new Material("air");
        public static Material Water = new Material("water");
        public static Material Lava = new Material("lava");

        public Material(string id)
        {
            Id = id;
            IsCollidable = true;
            LightOpacity = 0;
            RegisteredMaterials.Add(id, this);
        }
    }
}
