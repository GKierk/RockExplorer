/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 14-05-2023
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Interfaces;
using RockExplorer.Model;

// denne kode gør det muligt for brugeren at opdatere en eksisterende "Artifact" i databasen ved at udfylde en formular og klikke på en knap.
namespace RockExplorer.Pages.Artifacts__CRUD_
{
    public class Update : PageModel
    {
        private ArtifactCatalog catalog;

        [BindProperty]
        public Artifact artifact { get; set; }
        //private ICRUD catalog;
        public Update()
        {
            catalog = ArtifactCatalog.GetInstance();
        }
        public void OnGet(int id)
        {
            artifact = catalog.Read(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.Update(artifact);
            return RedirectToPage("Read");
        }
    }
}