using System.Drawing.Printing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Pronia.Helpers;
using Project_Pronia.Models;
using Project_Pronia.ViewModels;

namespace Project_Pronia.Controllers
{
	[AutoValidateAntiforgeryToken]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
        }
        public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVm registerVm)
		{
			if(!ModelState.IsValid)
			{
				return View();	 
			}
			AppUser user = new AppUser()
			{
				Name= registerVm.Name,
				Email= registerVm.Email,
				Surname= registerVm.Surname,
				UserName = registerVm.Username,
			};
			var result = await _userManager.CreateAsync(user, registerVm.Password);
			if(!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
					return View();
			}
			await _userManager.AddToRoleAsync(user,Roles.Member.ToString());
			await _signInManager.SignInAsync(user, isPersistent: false);

			return RedirectToAction("Index","Home");
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult>  Login(LoginVm loginVm , string? ReturnUrl)
        {
			if (!ModelState.IsValid)
			{
				return View();
			}

			AppUser user = await _userManager.FindByNameAsync(loginVm.UsernameOrEmail);
			if (user is null)
			{
				user = await _userManager.FindByEmailAsync(loginVm.UsernameOrEmail);
			    if(user == null)
				{
					ModelState.AddModelError("", "Invalid Username, Email or Password.");
					return View();
				}

			}
			var result =  _signInManager.CheckPasswordSignInAsync(user, loginVm.Password, true).Result;
			if (result.IsLockedOut)
			{
				ModelState.AddModelError("", "Try again a few minutes later");
				return View();
			}
			if(!result.Succeeded)
			{
				ModelState.AddModelError("", "Invalid Username,Email or Password.");
				return View();
			}
			await _signInManager.SignInAsync(user, loginVm.RememberMe);

			if(ReturnUrl != null)
			{
				return Redirect(ReturnUrl);
			}
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Home");
		}

		public async Task<IActionResult> CreateRole()
		{
			foreach (Roles item in Enum.GetValues(typeof(Roles)))
			{
				if(await _roleManager.FindByNameAsync(item.ToString()) == null)
				{
					await _roleManager.CreateAsync(new IdentityRole()
					{
						Name = item.ToString(),

					});
				}
			}
			
			return RedirectToAction("Index", "Home");
		}
	}
}
