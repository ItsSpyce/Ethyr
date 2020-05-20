namespace Ethyr
{
  internal static class ServerEnvironment
  {
#if DEBUG
    public const bool IsDebugging = true;
#else
    public const bool IsDebugging = false;
#endif
  }
}
