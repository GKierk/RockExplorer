/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Interfaces;
using RockExplorer.Model;

// denne kode g�r det muligt for brugeren at opdatere en eksisterende "Artifact" i databasen ved at udfylde en formular og klikke p� en knap.
namespace RockExplorer.Pages.Artifacts__CRUD_
{
    public class Update : PageModel
    {
        [BindProperty]
        public Artifact artifact { get; set; }
        private ICRUD catalog;
        public Update(ICRUD repository)
        {
            catalog = repository;
        }
        public void OnGet(int id)
        {
            artifact = catalog.GetArtifact(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateArtifact(artifact);
            return RedirectToPage("GetAllPizzas");
        }
    }
}