/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 *Edited by: Gabriel H. Kierkegaard, Date: 13-05-2023
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Interfaces;
using RockExplorer.Model;

//Kort sagt gør denne metode det muligt at hente og filtrere artefakter fra en database og vise dem på en webapplikation.
namespace RockExplorer.Pages.Artifacts__CRUD_
{ 
   public class Read : PageModel
   {
        //private ICRUD catalog;
        private ArtifactCatalog catalog;
        public Read()
        {
            catalog = ArtifactCatalog.GetInstance();
        }
        public Dictionary<int, Artifact> Artifacts { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Artifacts = catalog.ReadAll();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Artifacts = catalog.FilterArtifact(FilterCriteria);
            }

            return Page();
        }
   }
}