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
    public class HolidaysServices : IHolidaysServices
    {
        private readonly AppDb_Context _appDbContext;
        public HolidaysServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddHolidays(Holidays holidays)
        {
            try
            {
                var ifExists =  _appDbContext.Holiday.Where(x => x.id == holidays.id);
                if (ifExists.Any()) { 
                return false;
                }
                Holidays holiday = new() { 
                Name = holidays.Name,
                StartDate = holidays.StartDate,
                EndDate = holidays.EndDate,
                Days = holidays.Days,
                
                };
                _appDbContext.Holiday.Add(holiday);
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

        public async Task<bool> DeleteHolidays(int id)
        {
            try
            {
                if(_appDbContext.Holiday == null)
                {
                    return false;
                }
                var data = await _appDbContext.Holiday.FindAsync(id);
                if (data == null) { 
                return false;   
                }
                _appDbContext.Holiday.Remove(data);
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

       public async Task<IEnumerable<Holidays>> GetAllHoliday()
        {
            try
            {
                var result = await _appDbContext.Holiday.ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

       public async Task<Holidays> GetHolidaysById(int id)
        {
            try
            {
                var result = await _appDbContext.Holiday.FindAsync(id);
                return result;
            }
            catch
            {
                throw;
            }
        }

       public async Task<bool> UpdateHolidays(Holidays holidays)
        {
            try
            {
                _appDbContext.Holiday.Update(holidays);
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
    }
}
