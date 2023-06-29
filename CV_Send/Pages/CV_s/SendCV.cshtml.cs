using CV_Send.Data;
using CV_Send.imageservice;
using CV_Send.Model;
using CV_Send.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;

namespace CV_Send.Pages.CV_s
{
	public class SendCVModel : PageModel
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
		private readonly IImageUploadService ImS;
		private readonly GradeService gradeservice;
		[BindProperty]
		public List<string> CheckedSkills { get; set; }

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

		public SendCVModel(AppDataBaseContext db, GradeService gd, IImageUploadService ims)
		{
			DB = db;
			gradeservice = gd;
			ImS = ims;
		}
		public void OnGet()
		{
			Random rnd = new Random();

			x = rnd.Next(1, 21);
			y = rnd.Next(20, 51);

			v = x + y;

		}

		public async Task<IActionResult> OnPost(IFormFile Im)
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
				if (Im != null)
				{
					Programmer.image = await ImS.UploadImageAsync(Im);
				}
				Programmer.Grade = gradeservice.CalculateGrade(Programmer, CheckedSkills);
				Programmer.Programing_Skills = gradeservice.GenerateSkills(CheckedSkills);
				await DB.Programer.AddAsync(Programmer);
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
