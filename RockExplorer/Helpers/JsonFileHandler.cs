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
            if (File.Exists(JsonFileName))
            {

                using (var jsonFileReader = File.OpenText(JsonFileName))
                {
                    return JsonSerializer.Deserialize<Dictionary<int, Artifact>>(jsonFileReader.ReadToEnd());
                }
            }
            else
            {
                File.Create(JsonFileName);

                using (var jsonFileReader = File.OpenText(JsonFileName))
                {
                    return new Dictionary<int, Artifact>();
                }
            }


        }

        public static void WriteToJson(string JsonFileName)
        {
            ArtifactCatalog catalog = ArtifactCatalog.Instance;

            File.Delete(JsonFileName);
            File.Create(JsonFileName);

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
