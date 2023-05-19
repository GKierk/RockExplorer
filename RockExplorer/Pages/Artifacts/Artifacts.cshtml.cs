/*
 * Author: Gabriel H. Kierkegaard, Date: 13-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 13-05-2023
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Model;
using RockExplorer.ModelView;

// Dette er en modelklasse, der repræsenterer en side i applikationen, der viser en liste over artefakter.
// Den henter artefakterne fra ArtifactCatalog ved hjælp af ReadAll-metoden og gør dem tilgængelige for visning på siden.-Mk
namespace RockExplorer.Pages.Artifacts
{
    public class ArtifactsModel : PageModel
    {
        private ArtifactCatalog catalog;

        public Dictionary<int, Artifact> Artifacts { get; private set; }

        public ArtifactsModel()
        {
            catalog = ArtifactCatalog.Instance;
        }

        public void OnGet()
        {
            Artifacts = catalog.ReadAll();
        }
    }
}
