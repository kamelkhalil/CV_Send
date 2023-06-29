using CV_Send.Data;
using CV_Send.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CV_Send.Pages.CV_s
{
    public class DeleteModel : PageModel
    {
        public IEnumerable<SelectListItem> Natio { get; set; }
         = new List<SelectListItem>()
         {
                new SelectListItem{Value= "Lebanon", Text="Lebanon"},
                new SelectListItem{Value= "Palastine", Text="Palastine"},
                new SelectListItem{Value= "Japanese", Text="Japanese"},
                new SelectListItem{Value= "USA", Text="USA"},
                new SelectListItem{Value= "UK", Text="UK"},
                new SelectListItem{Value="KSA",Text="KSA"},
                new SelectListItem{Value="UAE",Text="UAE"},
                new SelectListItem{Value="QATAR",Text="QATAR"},
                new SelectListItem{Value="KAWIT",Text="KAWIT"},
                new SelectListItem{Value="JORDEN",Text="JORDEN"},
                new SelectListItem{Value="EYGEPT",Text="EYGEPT"},
                new SelectListItem{Value="DEUTSCHLAND",Text="DEUTSCHLAND"},
                new SelectListItem{Value="TURKEY",Text="TURKEY"},
                new SelectListItem{Value="POLEND",Text="POLEND"},
                new SelectListItem{Value="ITALY",Text="ITALY"}
         };

        public List<string> skills { get; set; }
          = new List<string>()
          {
                "PHP",
                "C",
                "C++",
                "Java",
                "C#",
                "REACT",
                "PAYTHON",
                "JAVASCRIPT",
                "CSS"
          };
        [BindProperty]
        public Programmer Programmer { get; set; }

        [BindProperty]
        [EmailAddress]
        [Required]
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public int x { get; set; }

        [BindProperty]

        public int y { get; set; }

        [BindProperty]
        public int v { get; set; }
        [BindProperty]
        public int sum { get; set; }

        private readonly AppDataBaseContext DB;




        public DeleteModel(AppDataBaseContext db)
        {
            DB = db;
        }
        public void OnGet(int id)
        {


            Programmer = DB.Programer.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {


            var programmerdb = DB.Programer.Find(Programmer.Id);
            if (programmerdb != null)
            {
                DB.Programer.Remove(programmerdb);
                await DB.SaveChangesAsync();
                return RedirectToPage("BrowseCv");
            }
            return RedirectToPage("Delete");

            return Page();
        }


    }
}