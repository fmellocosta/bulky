using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.ProductRepository
                .GetAll()
                .OrderBy(product => product.Id)
                .ToList();

            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }        

        [HttpPost]
        public IActionResult Create(Product objProduct)
        {
            if (objProduct.Title == objProduct.Author.ToString())
            {
                ModelState.AddModelError("name", "The Author can not be the same as the Title");
            }

            if (objProduct.Title == "test")
            {
                ModelState.AddModelError("", "The value 'test' is not valid");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Add(objProduct);
                _unitOfWork.Save();

                TempData["success"] = "Product created successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? categoryFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product objProduct)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(objProduct);
                _unitOfWork.Save();

                TempData["success"] = "Product edited successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? categoryFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Product? objProduct = _unitOfWork.ProductRepository.Get(u => u.Id == id);

            if (objProduct == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductRepository.Remove(objProduct);
            _unitOfWork.Save();

            TempData["success"] = "Product deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
