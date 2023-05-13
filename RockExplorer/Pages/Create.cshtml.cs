/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 */


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Interfaces;
using RockExplorer.Model;

namespace RockExplorer.Pages.Artifacts__CRUD_
// : Denne kode håndterer oprettelse af en ny kunstartefakt ved at modtage input fra en bruger og gemme det i en database.
{

    public class CreateArtifactModel : PageModel
    {
        [BindProperty]
        public Artifact Artifact { get; set; }
        private ICRUD catalog;
        public CreateArtifactModel(ICRUD repository)
        {
            catalog = repository;
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

            catalog.AddArtifact(Artifact);

            return RedirectToPage("GetAllArtifacts");
        }
    }
}
    
