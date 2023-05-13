/*
 *Authors: Mohamad Kassem
 *Date: 09-05-2023
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
    private ICRUD catalog;
        public Read(ICRUD repository)
    {
        catalog = repository;
    }
    public Dictionary<int, Artifact> Artifacts { get; private set; }

    [BindProperty(SupportsGet = true)]
    public string FilterCriteria { get; set; }

    public IActionResult OnGet()
    {
        Artifacts = catalog.AllArtifacts();
        if (!string.IsNullOrEmpty(FilterCriteria))
        {
            Artifacts = catalog.FilterArtifact(FilterCriteria);
        }

        return Page();
    }
}
}