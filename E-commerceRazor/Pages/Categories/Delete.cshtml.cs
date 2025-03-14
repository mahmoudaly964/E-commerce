using E_commerceRazor.Data;
using E_commerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerceRazor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        readonly ApplicationDbContext _db;
        [BindProperty]
        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {

            var obj = _db.Categories.Find(category.CategoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

