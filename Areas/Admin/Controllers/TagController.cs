using Microsoft.AspNetCore.Mvc;
using Project_Pronia.DAL;
using Project_Pronia.Models;

namespace Project_Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Tags> tags = _context.tags.ToList();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tags tags)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.tags.Add(tags);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Tags tag = _context.tags.Find(id);
            if (tag != null)
            {
                _context.tags.Remove(tag);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Tags tag = _context.tags.Find(id);
            return View(tag);
        }
        [HttpPost]
        public IActionResult Update(Tags newTag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Tags oldTag = _context.tags.Find(newTag.Id);
            if (oldTag != null)
            {
                return View();
            }
            oldTag.Name = newTag.Name;
            _context.tags.Add(newTag);

            return RedirectToAction("Index");
        }
    }
}
