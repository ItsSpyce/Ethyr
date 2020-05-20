using Ethyr.API.Events;
using Ethyr.API.Server;

namespace Ethyr.API.Nacht
{
  public interface IDynamicSource
  {
    /// <summary>
    ///   The type of the source. This can determine whether or not hotloading is implemented
    /// </summary>
    PluginType SourceType { get; }
    
    PluginInfo Info { get; }

    void OnLoad(object sender, IPluginEventArgs args);

    void OnUnload(object sender, IPluginEventArgs args);
  }
}
