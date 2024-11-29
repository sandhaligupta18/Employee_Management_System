using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IEmployeeServices
    {
        public Task<bool> AddEmployee(EmployeeDetailsView employeeDetails);
        public Task<IEnumerable<EmployeeDetails>> GetEmployee();
        public Task<EmployeeDetails> GetEmployeeById(string Empid);
        public Task<bool> UpdateEmployeeDetail(EmployeeDetails employeeDetail);
        public Task<bool> DeleteEmployeeDetail(string Empid);

    }
}
