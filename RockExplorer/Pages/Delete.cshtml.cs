/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
 */



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer.Interfaces;
using RockExplorer.Model;
//Kort sagt tillader denne metode brugeren at slette en Artifact fra samlingen ved at bruge webapplikationen.
namespace RockExplorer.Pages.Artifacts__CRUD_
{
    public class Delete : PageModel
    {

        [BindProperty]
        public Artifact artifact { get; set; }
        private ICRUD catalog;
        public Delete(ICRUD repository)
        {
            catalog = repository;
        }
        public IActionResult OnGet(int id)
        {
            artifact = catalog.GetArtifact(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            catalog.Delete(id);
            return RedirectToPage("GetAllArtifacts");
        }
    }
}