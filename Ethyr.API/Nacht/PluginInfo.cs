using Newtonsoft.Json;

namespace Ethyr.API.Nacht
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public struct PluginInfo
  {
    [JsonProperty("name")]
    public string Name;

    [JsonProperty("version")]
    public string Version;

    [JsonProperty("author")]
    public string Author;

    [JsonProperty("dependencies")]
    public string[] Dependencies;

    [JsonProperty("devDependencies")]
    public string[] DevDependencies;
  }
}
