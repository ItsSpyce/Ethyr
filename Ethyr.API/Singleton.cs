using System;

namespace Ethyr.API
{
  public abstract class Singleton<T> : IDisposable where T : Singleton<T>
  {
    public static T Instance { get; private set; }

    protected Singleton()
    {
      if (Instance != null)
      {
        Instance.Dispose();
      }
      Instance = (T)this;
    }

    public virtual void Dispose()
    {
      
    }
  }
}
