using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_Pronia.DAL;
using Project_Pronia.Models;

namespace Project_Pronia.Areas.Admin.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {

        AppDbContext _context;
        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Setting> setting = _context.Settings.ToList();
            return View(setting);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Setting setting)
        {
            if(!ModelState.IsValid)
            {
                _context.Settings.Add(setting);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(setting);
        }


        public IActionResult Update(string Key)
        {
            Setting setting = _context.Settings.Find(Key);
            if(setting == null)
            {
                return View();
            }
            return View(setting);
        }


        [HttpPost]
        public IActionResult Update(Setting newSetting)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Setting oldSetting = _context.Settings.Find(newSetting.Key); 
            if(oldSetting == null)
            {
                return View();
            }
            oldSetting.Key = newSetting.Key;
            oldSetting.Value = newSetting.Value;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string Key)
        {
            var setting = _context.Settings.FirstOrDefault(s=> s.Key == Key);
            if (setting == null)
            {
                return View();
            }
            _context.Settings.Remove(setting);  
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
