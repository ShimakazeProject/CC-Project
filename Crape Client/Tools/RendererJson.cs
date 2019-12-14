using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crape_Client.Tools
{
    public struct RendererJson
    {
        public string Name { get; private set; }
        public string Dll { get; private set; }
        public List<string> Files { get; private set; }
        public RendererJson(JsonObject json)
        {
            Files = new List<string>();
            JsonValue name, dll, files;
            json.TryGetValue("Name", out name);
            json.TryGetValue("Dll", out dll);
            json.TryGetValue("Files", out files);
            if (name.JsonType == JsonType.String) Name = name;
            else throw new FormatException();
            if (dll.JsonType == JsonType.String) Dll = dll;
            else throw new FormatException();
            if (files != null)
                if (files.JsonType == JsonType.Array)
                    foreach (JsonValue file in (JsonArray)files)
                        if (file.JsonType == JsonType.String) Files.Add(file);
                        else throw new FormatException();
                else throw new FormatException();
        }
    }
}
