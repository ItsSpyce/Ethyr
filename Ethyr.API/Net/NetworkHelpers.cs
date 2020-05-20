namespace Ethyr.API.Net
{
  public static class NetworkHelpers
  {
    public static string ToString(this IPacket packet)
    {
      return $"[Packet id={packet.Id} direction={packet.Direction}]";
    }
  }
}
