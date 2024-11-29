using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IPayRollServices
    {
        public Task<bool> AddPayroll(Payroll payroll);
        public Task<IEnumerable<Payroll>> GetALlPayroll();
        public Task<Payroll> GetPayroll(string Empid);
        public Task<bool> UpdatePayroll(Payroll payroll);
        public Task<bool> DeletePayroll(string Empid);


    }
}
