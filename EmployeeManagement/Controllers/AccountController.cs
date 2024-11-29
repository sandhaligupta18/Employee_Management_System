using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDb_Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountServices _accountServices;

		public AccountController(IAccountServices accountServices)
		{
			_accountServices = accountServices;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllRegisterUsers()
		{
			var data = await _accountServices.GetAllUsers();
			return View(data);
		}
		[HttpGet]
		public IActionResult CreateUser()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(ApplicationUserModel applicationUser)
		{
			try
			{
				if (ModelState.IsValid) {

					var result = await _accountServices.CreateUser(applicationUser);
					if (result)
					{
						return RedirectToAction("GetAllRegisterUsers");
					}				
				}
				return View();
			}
			catch
			{
				throw;
			}
		}
	

		[HttpGet]
		public ActionResult CreateRole()
		{
			return View();
		}
		[HttpPost]
		 public async Task<IActionResult> CreateRole(UserRole userRole)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var result = await _accountServices.CreateRole(userRole);
					if (result)
					{
						return RedirectToAction("CreateUser");
					}
				}
				return View();
			}
			catch {
				throw;
              }
		}

	}
}
