using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
	public interface IAccountServices
	{
		public Task<bool> CreateUser(ApplicationUserModel applicationUser);
		public Task<IEnumerable<ApplicationUser>> GetAllUsers();
		public Task<bool> CreateRole(UserRole userrole);

	}
}
