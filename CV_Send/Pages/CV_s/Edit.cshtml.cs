using CV_Send.Data;
using CV_Send.Model;
using CV_Send.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace CV_Send.Pages.CV_s
{
	public class EditModel : PageModel
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


		private readonly AppDataBaseContext DB;
		private readonly GradeService gradeservice1;

		[BindProperty]
		public Programmer Programmer { get; set; }
		[BindProperty]
		public List<string> CheckedSkills { get; set; }


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
		public List<string> Checkedd { get; set; }

		public EditModel(AppDataBaseContext db, GradeService gradeservice)
		{
			DB = db;
			gradeservice1 = gradeservice;
		}
		public void OnGet(int id)
		{
			Programmer = DB.Programer.Find(id);
			Checkedd = Programmer.Programing_Skills.Split(',').ToList();

			Random rnd = new Random();

			x = rnd.Next(1, 21);
			y = rnd.Next(20, 51);

			v = x + y;


		}

		public async Task<IActionResult> OnPost()
		{
			if (sum != v)
			{
				ModelState.AddModelError("Sum Validation", "The Summation is incorrect");
			}

			if (Programmer.Email != ConfirmEmail)
			{
				ModelState.AddModelError("Email Validation", "The Email is incorrect");
			}

			if (ModelState.IsValid)
			{
				Programmer.Grade = gradeservice1.CalculateGrade(Programmer, CheckedSkills);
				Programmer.Programing_Skills = gradeservice1.GenerateSkills(CheckedSkills);
				DB.Programer.Update(Programmer);
				await DB.SaveChangesAsync();
				return RedirectToPage("BrowseCv");
			}
			else
			{
				return Page();
			}
		}


	}
}