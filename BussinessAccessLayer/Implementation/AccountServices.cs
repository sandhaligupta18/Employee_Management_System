using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDb_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
	public class AccountServices:IAccountServices
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly AppDb_Context _appDbContext;
		public AccountServices(AppDb_Context appDb_Context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) { 
		_appDbContext = appDb_Context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		 public async Task<bool> CreateUser(ApplicationUserModel applicationUser)
		{
			try
			{
				var users = new ApplicationUser
				{
					Empid = applicationUser.Empid,
					FirstName = applicationUser.FirstName,
					LastName = applicationUser.LastName,
					Email = applicationUser.Email,
					UserName = applicationUser.FirstName + applicationUser.LastName.ToLower(),
					RegisterAs = applicationUser.RegisterAs,
					PasswordHash = applicationUser.Password,
				};
				var result = await _userManager.CreateAsync(users, applicationUser.Password);
				if (result.Succeeded) {
					var roleExists = await _roleManager.RoleExistsAsync(applicationUser.RegisterAs);
					if (roleExists)
					{
						 IdentityResult results = await _userManager.AddToRoleAsync(users, applicationUser.RegisterAs);
					}
					return true;
				}
				else
				{
					return false;
				}

			}
			catch
			{
				return false;	
			}
		}

	  public	async Task<IEnumerable<ApplicationUser>> GetAllUsers()
		{
		 var result = await _userManager.Users.ToListAsync();
			return result;
		}
		public async Task<bool> CreateRole(UserRole userRole)
		{
			try
			{
				IdentityRole roles = new IdentityRole()
				{
					Name = userRole.RoleName
				};
				var result = await _roleManager.CreateAsync(roles);
				if (result.Succeeded) { 
				return true;}
				else
				{
				 return	false;
				}

			}
			catch
			{
return false;
			}
		}
	}
}
