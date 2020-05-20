namespace Ethyr.Nacht
{
  /// <summary>
  ///   Represents a DLL file loaded by Ethyr. These are incapable
  ///   of being hot reloaded but can contain embedded resources and
  ///   larger external library usage.
  /// </summary>
  public abstract class Mod
  {
    [EventHandler("Game.Load")]
    public virtual void Load()
    {

    }

    [EventHandler("Game.Unload")]
    public virtual void Unload()
    {

    }

    [EventHandler("Game.Sleep")]
    public virtual void Sleep()
    {

    }

    [EventHandler("Game.Wake")]
    public virtual void Wake()
    {

    }
  }
}