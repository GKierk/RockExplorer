/*
 * Author: Gabriel H. Kierkegaard, Date: 13-05-2023
 * Edited by: Gabriel H. Kierkegaard, Date: 13-05-2023
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Model;
using RockExplorer.ModelView;

// Dette er en modelklasse, der repr�senterer en side i applikationen, der viser en liste over artefakter.
// Den henter artefakterne fra ArtifactCatalog ved hj�lp af ReadAll-metoden og g�r dem tilg�ngelige for visning p� siden.-Mk
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
