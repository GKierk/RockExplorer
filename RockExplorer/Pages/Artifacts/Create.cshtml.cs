/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 14-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 15-05-2023
 */


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Interfaces;
using RockExplorer.Model;

namespace RockExplorer.Pages.Artifacts
// : Denne kode håndterer oprettelse af en ny kunstartefakt ved at modtage input fra en bruger og gemme det i en database.
{

    public class CreateArtifactModel : PageModel
    {
        private ArtifactCatalog catalog;

        [BindProperty]
        public Artifact Artifact { get; set; }
        //private ICRUD catalog;

        public CreateArtifactModel()
        {
            catalog = ArtifactCatalog.Instace;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            catalog.Create(Artifact);
            return RedirectToPage("Read");
        }
    }
}

