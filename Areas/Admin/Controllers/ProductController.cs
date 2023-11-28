using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Pronia.Areas.ViewModels;
using Project_Pronia.DAL;
using Project_Pronia.Models;

namespace Project_Pronia.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		AppDbContext _context;
		public ProductController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			List<Products> products = await _context.products.Include(p => p.Categories)
				.Include(p => p.ProductTags).ThenInclude(proT => proT.Tags).ToListAsync();
			return View(products);
		}


		public async Task<IActionResult> Create()
		{
			ViewBag.Categories = await _context.categories.ToListAsync();
			ViewBag.Tags = await _context.tags.ToListAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductVM createProductVM)
		{
			ViewBag.Categories = await _context.categories.ToListAsync();
			ViewBag.Tags = await _context.tags.ToListAsync();
			if (!ModelState.IsValid)
			{
				return View();
			}
			bool resultcategory = await _context.categories.AnyAsync(c => c.Id == createProductVM.CategoryId);
			if (!resultcategory)
			{
				ModelState.AddModelError("CategoryId", "There is no such category");
				return View();
			}
			Products product = new Products()
			{
				Title = createProductVM.Title,
				Price = createProductVM.Price,
				SKU = createProductVM.SKU,
				Description = createProductVM.Description,
				CategoryId = createProductVM.CategoryId,
			};
			await _context.products.AddAsync(product);
			await _context.SaveChangesAsync();


			return RedirectToAction("Index");

		}
	}
}


