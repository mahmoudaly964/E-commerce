using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Areas.Admin.Controllers
{

    
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product has been added successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Product = _unitOfWork.Product.Get(obj => obj.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        [HttpPost]

        public IActionResult Edit(Product Product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(Product);
                _unitOfWork.Save();
                TempData["success"] = "Product has been updated successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Product = _unitOfWork.Product.Get(obj => obj.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {

            var Product = _unitOfWork.Product.Get(obj => obj.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(Product);
            _unitOfWork.Save();
            TempData["success"] = "Product has been deleted successfully";
            return RedirectToAction("Index", "Product");
        }

    }
}

