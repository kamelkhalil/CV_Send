using CV_Send.Data;
using CV_Send.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV_Send.Pages.CV_s
{
	public class ViewModel : PageModel
	{
		[BindProperty]
		public Programmer programmer { get; set; }
		private readonly AppDataBaseContext _db;

		public ViewModel(AppDataBaseContext db)
		{
			_db = db;
		}

		public void OnGet(int id)
		{
			programmer = _db.Programer.Find(id);
		}
	}
}
