using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API
{
  public struct Vector3F : IEquatable<Vector3F>
  {
    public float X;
    public float Y;
    public float Z;

    public Vector3F(float x, float y, float z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public bool Equals(Vector3F other) => X == other.X && Y == other.Y && Z == other.Z;

    public override bool Equals(object obj) => obj is Vector3F vector ? this.Equals(vector) : false;

    public override int GetHashCode() => X.GetHashCode() ^ (Y.GetHashCode() << 2) ^ (Z.GetHashCode() >> 2);

    public static bool operator ==(Vector3F a, Vector3F b) => a.Equals(b);

    public static bool operator !=(Vector3F a, Vector3F b) => !a.Equals(b);
  }
}
