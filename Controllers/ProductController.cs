using Microsoft.AspNetCore.Mvc;
using PCPortal.Data;
using PCPortal.Models;

namespace PCPortal.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        public IActionResult ComputerPartsIndex()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        public IActionResult ComputerSystemsIndex()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        public IActionResult ComputerAccessoriesIndex()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        public IActionResult LaptopsAndAccessoriesIndex()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        public IActionResult GamingChairsIndex()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        public IActionResult CablesIndex()
        {
            IEnumerable<Product> objProductsList = _db.Products;
            return View(objProductsList);
        }
        //GET
        [Route ("Product/ProductIndex/{productId}")]
        public IActionResult ProductIndex(int? productId)
        {
            var product = _db.Products.Find(productId);

            if (product == null)
            {
                return NotFound();
            }

            return View("ProductIndex", product);
        }
        //POST
        [HttpPost]
        public IActionResult AddDescription(int productId, string description)
        {
            try
            {
                var product = _db.Products.Find(productId);

                if (product != null)
                {
                    product.Description = description;
                    _db.SaveChanges();
                }

                // Return a plain text response
                return Content("Description added successfully");
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return Content("Error adding description: " + ex.Message);
            }
        }

        //GET
        public IActionResult Add() 
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product obj) 
        {
            if (obj.price == obj.salePrice)
            {
                ModelState.AddModelError("salePrice", "The new sale price cannot be the same as old price. Please enter another price!");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Product added successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Products.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (obj.price == obj.salePrice)
            {
                ModelState.AddModelError("salePrice", "The new sale price cannot be the same as old price. Please enter another price!");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
