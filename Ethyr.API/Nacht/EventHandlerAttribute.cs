using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Ethyr.Nacht
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
  public class EventHandlerAttribute : Attribute
  {
    public readonly string EventName;
    public readonly bool RunAsync;

    public EventHandlerAttribute(string name) : this(name, false)
    {

    }

    public EventHandlerAttribute(string name, bool async)
    {
      EventName = name;
      RunAsync = async;
    }
  }
}