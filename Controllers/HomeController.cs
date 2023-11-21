using Microsoft.AspNetCore.Mvc;
using Project_Pronia.DAL;
using Project_Pronia.ViewModels;
using Project_Pronia.Models;

namespace Project_Pronia.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM HomeVm = new HomeVM()
            {
                categories = _context.categories.ToList(),
                productImages = _context.productImages.ToList(),
                products = _context.products.ToList(),
                productTags = _context.productTags.ToList(),
                sliders = _context.sliders.ToList(),
                tags = _context.tags.ToList()
            };
            

            return View(HomeVm);
        }
    }
}
