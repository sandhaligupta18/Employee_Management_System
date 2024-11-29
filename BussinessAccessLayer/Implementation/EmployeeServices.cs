using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDb_Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDb_Context _appDBContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public EmployeeServices(AppDb_Context appDbContext, IHostingEnvironment hostingEnvironment)
        {
            _appDBContext = appDbContext;
            _hostingEnvironment = hostingEnvironment;
}
        public async Task<bool> AddEmployee(EmployeeDetailsView employeeDetails)
        {
            try
            {
                var ifExists = _appDBContext.EmployeeDetail.Where(x => x.Empid == employeeDetails.Empid);
                if (ifExists.Any()) {
                    return false;
                }
                else
                {
                    string uniqueFileName = UploadedFile(employeeDetails);
                    EmployeeDetails employee = new() { 
                   Empid = employeeDetails.Empid,
                    EmpName = employeeDetails.EmpName,
                    Email = employeeDetails.Email,
                    Address = employeeDetails.Address,
                    Contact = employeeDetails.Contact,
                    Department = employeeDetails.Department,
                    Designation = employeeDetails.Designation,
                    Salary = employeeDetails.Salary,
                    Gender = employeeDetails.Gender,
                    HireDate = employeeDetails.HireDate,
                    ProfilePicture=uniqueFileName, 
                    };
                    _appDBContext.EmployeeDetail.Add(employee);
                    var result = await _appDBContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch(Exception)
            {
                throw;
            }
        }

         public async Task<IEnumerable<EmployeeDetails>> GetEmployee()
        {
            return await _appDBContext.EmployeeDetail.ToListAsync();
        }

       public async Task<EmployeeDetails> GetEmployeeById(string Empid)
        {
            return await _appDBContext.EmployeeDetail.FindAsync(Empid);
        }

       public async Task<bool> UpdateEmployeeDetail(EmployeeDetails employeeDetail)
        {
            try
            {
                _appDBContext.EmployeeDetail.Update(employeeDetail);
                var result = await _appDBContext.SaveChangesAsync();
                if (result > 0) {
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

      public async Task<bool> DeleteEmployeeDetail(string Empid)
        {
            try
            {
                if(_appDBContext.EmployeeDetail == null)
                {
                    return false;
                }
                var data = await _appDBContext.EmployeeDetail.FindAsync(Empid);
                if (data == null) {
                    return false;
                }
                _appDBContext.EmployeeDetail.Remove(data);
                var result = await _appDBContext.SaveChangesAsync();
                if (result > 0) {
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

        private string UploadedFile(EmployeeDetailsView model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                Random rndm = new Random();
                int uniqnum = rndm.Next();
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + (uniqnum + model.ProfileImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        

    }
}
