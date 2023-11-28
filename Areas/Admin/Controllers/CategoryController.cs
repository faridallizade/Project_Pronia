 using Microsoft.AspNetCore.Mvc;
using Project_Pronia.DAL;
using Project_Pronia.Models;

namespace Project_Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Categories> categories = _context.categories.ToList();
            return View(categories);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories category)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _context.categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Categories category = _context.categories.Find(id);
            if(category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Categories categories = _context.categories.Find(id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult Update(Categories newCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Categories oldcategory = _context.categories.Find(newCategory.Id);
            if (oldcategory != null)
            {
                return View();
            }
            oldcategory.Name = newCategory.Name;
            _context.categories.Add(newCategory);

            return RedirectToAction("Index");
        }
    }
}
