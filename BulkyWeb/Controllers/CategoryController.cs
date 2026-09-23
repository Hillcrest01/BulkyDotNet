using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        //declare a private varible
        private readonly ApplicationDBContext _db;
        //create a constructor and pass whatever you get from the ApplicationDBContext to our local variable _db.
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //for example if you need to ensure that the name is not equal to the display order, here is the if condition
            //We use AddModelError to pass the error to the view
            //If you leave the key empty, it will display in the validation summary and not on any field.
            //if(obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The name must  not be the same as the display order");
            //}
            //if (obj.Name != null && obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is not allowed in the name field");
            //}
            if (ModelState.IsValid) { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
            //the return redirecttoaction takes in as parameters the function name, controller name.
            //if in the same controller, then there is no need to define the controller, just define the function name.
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? categoryToEdit = _db.Categories.Find(id);
            if(categoryToEdit == null)
            {
                return NotFound();
            }

            return View(categoryToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryToDelete= _db.Categories.Find(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            return View(categoryToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if(id == null ||id == 0){
                return NotFound();
            }

            Category? categoryToDelete = _db.Categories.Find(id);
            if (categoryToDelete != null)
            {
                _db.Categories.Remove(categoryToDelete);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
