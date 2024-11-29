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
    public class DesignationServices:IDesignationServices
    {
        private readonly AppDb_Context _appDbContext;
        public DesignationServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddDesignation(Designation designation)
        {
            try
            {
                var ifExist = _appDbContext.Designation.Where(x => x.id == designation.id);
                if (ifExist.Any()) {
                    return false;
                }

                Designation designations = new() { 
                DesignationName = designation.DesignationName
                
                };
                _appDbContext.Designation.Add(designations);
                var result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else { 
                    return false;
                }  
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Designation>> GetDesignations()
        {
            try
            {
                var result = await _appDbContext.Designation.ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Designation> GetDesignationById(int id)
        {
            try
            {
                var result = await _appDbContext.Designation.FindAsync(id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateDesignation(Designation designation)
        {
            try
            {
                _appDbContext.Designation.Update(designation);
                   var result = await _appDbContext.SaveChangesAsync();
                if (result > 0) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

       public async Task<bool> DeleteDesignation(int id)
        {
            try
            {
                if(_appDbContext.Designation == null)
                {
                    return false;
                }
                var data = await _appDbContext.Designation.FindAsync(id);
                if(data == null)
                {
                    return false;
                }
                _appDbContext.Designation.Remove(data);
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
