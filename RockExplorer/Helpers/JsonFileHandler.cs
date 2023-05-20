using Microsoft.Extensions.Logging;
using System.Text.Json;
using RockExplorer.Model;
using System.Text.Json.Serialization;
using RockExplorer.ModelView;

namespace RockExplorer.Helpers
{
    public class JsonFileHandler
    {
        public static Dictionary<int, Artifact> ReadJson(string JsonFileName)
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                if (JsonFileName != null)
                {
                    return JsonSerializer.Deserialize<Dictionary<int, Artifact>>(jsonFileReader.ReadToEnd());
                }
                else
                {
                    return null;
                }
            }
        }

        public static void WriteToJson(string JsonFileName)
        {
            ArtifactCatalog catalog = ArtifactCatalog.Instance;

            using (FileStream outputStream = File.OpenWrite(JsonFileName))
            {
                var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                });

                JsonSerializer.Serialize<Dictionary<int, Artifact>>(writer, catalog.Artifacts);
            }
        }
    }
}
