using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API
{
  public struct Vector4F : IEquatable<Vector4F>
  {
    public const float KEPSILON = 1E-05f;

    public float W;
    public float X;
    public float Y;
    public float Z;

    public Vector4F(float x, float y, float z, float w = 0)
    {
      W = w;
      X = x;
      Y = y;
      Z = z;
    }

    public bool Equals(Vector4F other) => W == other.W && X == other.X && Y == other.Y && Z == other.Z;
  }
}
