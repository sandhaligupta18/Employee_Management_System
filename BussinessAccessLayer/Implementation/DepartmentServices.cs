using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDb_Context;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {

        private readonly AppDb_Context _appDbContext;
        public DepartmentServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }


         public async Task<bool> CreateDepartment(Departments departments)
        {
            try
            {

                var ifExists = _appDbContext.Department.Where(x => x.id == departments.id);
                if (ifExists.Any())
                {
                    return false;
                }
                Departments departmentse = new()
                {
                    DepartmentName = departments.DepartmentName
                };
                _appDbContext.Department.Add(departmentse);
                var result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Departments>> GetAllDepartments()
        {
            var result = await _appDbContext.Department.ToListAsync();
            return result;
        }

       public async Task<Departments> GetDepartmentById(int id)
        {
            var result = await  _appDbContext.Department.FindAsync(id);
            return result;
        }

      public async Task<bool> UpdateDepartment(Departments departments)
        {
            try
            {
                _appDbContext.Department.Update(departments);
                var result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

       public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                if (_appDbContext.Department == null)
                {
                    return false;
                }
                var ifExist =await _appDbContext.Department.FindAsync(id);
                if (ifExist == null)
                {
                    return false;
                }
                _appDbContext.Department.Remove(ifExist);
                var result = await _appDbContext.SaveChangesAsync();
                if(result>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
