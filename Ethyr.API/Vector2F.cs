using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API
{
  public struct Vector2F : IEquatable<Vector2F>
  {
    public float X;
    public float Y;

    public Vector2F(float x, float y)
    {
      X = x;
      Y = y;
    }

    public bool Equals(Vector2F other) => X == other.X && Y == other.Y;

    public override int GetHashCode() => X.GetHashCode() ^ (Y.GetHashCode() << 2);
  }
}
