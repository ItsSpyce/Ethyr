using Ethyr.API.Exceptions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ethyr.Server
{
  public class ResourcesLoader
  {
    // we have a choice: JSON or XML. Lets let it do both, just for vanilla's sake.
    public static void MaterialsFromXML(XmlDocument xml)
    {
      if (!xml.HasChildNodes) throw new ServerLoadException("No material data found");
      foreach (XmlNode entry in xml.ChildNodes)
      {
        if (entry.NodeType != XmlNodeType.Element || entry.Name.ToLower() != "material") continue;
        var element = (XmlElement)entry;
        var id = element.GetAttribute("id");
        if (id == null) continue;
        var materialProperties = element.ChildNodes;
        foreach (XmlNode materialProperty in materialProperties)
        {
          if (materialProperty.NodeType != XmlNodeType.Element || materialProperty.Name.ToLower() != "property") continue;
          var property = (XmlElement)materialProperty;
          var name = property.GetAttribute("name");
          var type = property.GetAttribute("type");
          var value = property.GetAttribute("value");
        }
      }
    }

    public static void MaterialsFromJSON(JArray json)
    {
      if (json.Count == 0) throw new ServerLoadException("No material data found");
      foreach (JObject entry in json)
      {
        var id = entry["id"];
        var name = entry["name"].ToString();
        var type = entry["type"].ToString();
        var value = entry["value"].ToString();
      }
    }
  }
}
