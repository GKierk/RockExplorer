/*
 * Author: Gabriel H. Kierkegaard, Date: 13-05-2023
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Model;

namespace RockExplorer.Pages.Shared
{
    public class ArtifactsModel : PageModel
    {
        private ArtifactCatalog catalog;

        public Dictionary<int, Artifact> Artifacts { get; private set; }

        public ArtifactsModel()
        {
            catalog = new ArtifactCatalog();
        }

        public void OnGet()
        {
            Artifacts = catalog.ReadAll();
        }
    }
}
