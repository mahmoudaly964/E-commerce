using E_commerce.DataAccess.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.DataAccess.Repository.IRepository;

namespace E_commerce.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList=_unitOfWork.Category.GetAll().ToList();
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
               _unitOfWork.Category.Add(category);
               _unitOfWork.Save();
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
            var category =_unitOfWork.Category.Get(obj=>obj.CategoryId==id);
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
               _unitOfWork.Category.Update(category);
               _unitOfWork.Save();
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
            var category = _unitOfWork.Category.Get(obj => obj.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {
            
            var category =_unitOfWork.Category.Get(obj => obj.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
           _unitOfWork.Category.Remove(category);
           _unitOfWork.Save();
            TempData["success"] = "Category has been deleted successfully";
            return RedirectToAction("Index", "Category");
        }

    }
}
