/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 14-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 15-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 17-05-2023
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Model;
using RockExplorer.ModelView;

// denne kode g�r det muligt for brugeren at opdatere en eksisterende "Artifact" i databasen ved at udfylde en formular og klikke p� en knap.
namespace RockExplorer.Pages.Artifacts__CRUD_
{
    public class Update : PageModel
    {
        private ArtifactCatalog catalog;

        [BindProperty]
        public Artifact artifact { get; set; }

        public Update()
        {
            catalog = ArtifactCatalog.Instance;
        }
        public IActionResult OnGet(int id)
        {
            catalog.key = id;
            artifact = catalog.Read(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.Update(catalog.key, artifact);
            return RedirectToPage("Read");
        }
    }
}