using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IDepartmentServices
    {
        public Task<bool> CreateDepartment(Departments departments);
        public Task<IEnumerable<Departments>>  GetAllDepartments();
        public Task<Departments> GetDepartmentById(int id);
        public Task<bool> UpdateDepartment(Departments departments);
        public Task<bool> DeleteDepartment(int id);

        



    }
}
