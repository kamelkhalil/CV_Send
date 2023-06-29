using CV_Send.Data;
using CV_Send.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CV_Send.Pages.CV_s
{
	public class BrowseCvModel : PageModel
	{
		public IEnumerable<Programmer> programmers;
		public AppDataBaseContext _db { get; set; }
		public BrowseCvModel(AppDataBaseContext db)
		{
			_db = db;
		}
		public void OnGet()
		{
			programmers = _db.Programer;
		}
	}
}
