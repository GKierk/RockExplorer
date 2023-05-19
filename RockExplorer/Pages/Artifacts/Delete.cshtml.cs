/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 13-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 15-05-2023
 */



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Model;
using RockExplorer.ModelView;
// Denne den del af koden sørger for at slette en specifik artefakt baseret på dens ID.-MK
// På GET-anmodningen hentes artefacten fra kataloget, og hvis den ikke findes, vises en fejlside.-MK
// På POST-anmodningen slettes artefacten fra kataloget, og brugeren omdirigeres til læsesiden.-MK

namespace RockExplorer.Pages.Artifacts__CRUD_

{
    public class Delete : PageModel
    {

        [BindProperty]
        public Artifact artifact { get; set; }
        private ArtifactCatalog catalog;
        //private ICRUD catalog;
        public Delete()
        {
            catalog = ArtifactCatalog.Instance;
        }
        public IActionResult OnGet(int id)
        {
            artifact = catalog.Read(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            catalog.Delete(id);
            return RedirectToPage("Read");
        }
    }
}