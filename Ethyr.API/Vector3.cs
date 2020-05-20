using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API
{
  public struct Vector3 : IEquatable<Vector3>
  {
    public int X;
    public int Y;
    public int Z;

    public Vector3(int x, int y, int z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public bool Equals(Vector3 other) => X == other.X && Y == other.Y && Z == other.Z;

    public override bool Equals(object obj) => obj is Vector3 vector ? this.Equals(vector) : false;

    public override int GetHashCode() => X * 8976890 + Y * 981131 + Z;

    public static bool operator ==(Vector3 a, Vector3 b) => a.Equals(b);

    public static bool operator !=(Vector3 a, Vector3 b) => !a.Equals(b);
  }
}
