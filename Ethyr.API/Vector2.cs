using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API
{
  public struct Vector2 : IEquatable<Vector2>
  {
    public int X;
    public int Y;

    public Vector2(int x, int y)
    {
      X = x;
      Y = y;
    }

    public bool Equals(Vector2 other) => other.X == X && other.Y == Y;

    public override int GetHashCode() => X.GetHashCode() ^ (Y.GetHashCode() << 2);
  }
}
