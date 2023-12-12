using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_Pronia.DAL;
using Project_Pronia.Models;
using Project_Pronia.ViewModels;

namespace Project_Pronia.Controllers
{
	public class CartController : Controller
	{
		AppDbContext _context;

		public CartController (AppDbContext context)
		{
			_context = context;
		}

		//public ActionResult Index()
		//{
		//	var jsonCookie = Request.Cookies["Basket"];
		//	List<CartProductVm> CartProduct = new List<CartProductVm>();
		//	if(jsonCookie != null)
		//	{
		//		var cookieProd = JsonConvert.DeserializeObject<List<CartCartProductVm>>(jsonCookie);

		//		bool checkCount = false;
		//		List<CartProductVm> deletedCookie = new List<CartProductVm>();
		//		foreach (var item in cookieProd)
		//		{
		//			Products product = _context.products.Where(p=>p.Deleted == false).Include(p=>p.Images)
		//		}
		//	}

		//}
	}
}
