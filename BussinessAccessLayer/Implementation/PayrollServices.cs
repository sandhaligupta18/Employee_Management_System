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
    public class PayrollServices:IPayRollServices
    {
        private readonly AppDb_Context _appDbContext;
        public PayrollServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddPayroll(Payroll payroll)
        {
            try
            {
                Payroll payrolls = new() { 
                
                Empid = payroll.Empid,
                EmpName = payroll.EmpName,
                Salary= payroll.Salary,
                Deduction = payroll.Deduction,
                Loan = payroll.Loan,
                Month = payroll.Month,
                WorkingHours = payroll.WorkingHours,
                TotalPaid = payroll.TotalPaid,
                Pending = payroll.Pending,
                Status = payroll.Status,
                PaidType = payroll.PaidType,
                PayDate=payroll.PayDate,
                };

                _appDbContext.Payroll.Add(payrolls);
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

        public async Task<bool> DeletePayroll(string Empid)
        {
            try
            {
                if(_appDbContext.Payroll == null)
                {
                    return false;
                }
                var data = await _appDbContext.Payroll.FindAsync(Empid);
                if(data== null)
                {
                    return false;
                }
                _appDbContext.Payroll.Remove(data);
                var result = await _appDbContext.SaveChangesAsync();
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

        public async Task<IEnumerable<Payroll>> GetALlPayroll()
        {
            try
            {
                var result = await _appDbContext.Payroll.ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

       public async Task<Payroll> GetPayroll(string Empid)
        {
            try
            {
                var result = await _appDbContext.Payroll.FindAsync(Empid);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdatePayroll(Payroll payroll)
        {
            try
            {
               _appDbContext.Payroll.Update(payroll);
                var result = await _appDbContext.SaveChangesAsync();
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
    }
}
