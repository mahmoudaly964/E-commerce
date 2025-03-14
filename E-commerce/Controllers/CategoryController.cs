using E_commerce.DataAccess.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.DataAccess.Repository.IRepository;

namespace E_commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
           _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList=_categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
               _categoryRepo.Add(category);
               _categoryRepo.Save();
                TempData["success"] = "Category has been added successfully";
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category =_categoryRepo.Get(obj=>obj.CategoryId==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]

        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
               _categoryRepo.Update(category);
               _categoryRepo.Save();
                TempData["success"] = "Category has been updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _categoryRepo.Get(obj => obj.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {
            
            var category =_categoryRepo.Get(obj => obj.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
           _categoryRepo.Remove(category);
           _categoryRepo.Save();
            TempData["success"] = "Category has been deleted successfully";
            return RedirectToAction("Index", "Category");
        }

    }
}
