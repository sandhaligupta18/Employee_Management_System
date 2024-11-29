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
    public class LeavesServices : ILeavesServices
    {
        private readonly AppDb_Context _appDbContext;
        public LeavesServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

            public async Task<bool> AddLeaves(Leaves leaves)
        {
            try
            {
                Leaves leave = new() {
                Empid = leaves.Empid,
                EmpName = leaves.EmpName,
                ApplyDate = leaves.ApplyDate,
                LeaveType = leaves.LeaveType,
                LeaveStatus = leaves.LeaveStatus,
                StartDate = leaves.StartDate,
                EndDate = leaves.EndDate,
                NoofDays = leaves.NoofDays,
                
                };
                _appDbContext.Leave.Add(leave);
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

         public async Task<bool> DeleteLeaves(string Empid)
        {
            try
            {
                if (_appDbContext.Leave == null) { 
                return false;
                }
                var data = await _appDbContext.Leave.FindAsync(Empid);
                if(data == null)
                {
                    return false;
                }
                _appDbContext.Leave.Remove(data);
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

        public async Task<IEnumerable<Leaves>> GetAllLeaves()
        {
            try
            {
                var data = await _appDbContext.Leave.ToListAsync();
                return data;
            }
            catch
            {
                throw;
            }
        }

         public async Task<Leaves> GetLeavesById(string Empid)
        {
            try
            {
                var data = await _appDbContext.Leave.FindAsync(Empid);
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateLeaves(Leaves leaves)
        {
            try
            {
                _appDbContext.Leave.Update(leaves);
                var result =await _appDbContext.SaveChangesAsync();
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
    }
}
