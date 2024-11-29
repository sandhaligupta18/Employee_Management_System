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
    public class AttendanceServices : IAttendanceServices
    {
        private readonly AppDb_Context _appDbContext;
        public AttendanceServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateAttendance(Attendance attendance)
        {
            try
            {
                Attendance attendances = new() { 
                Empid = attendance.Empid,
                EmpName = attendance.EmpName,
                SignIn = attendance.SignIn,
                SignOut = attendance.SignOut,
                WorkingHours = attendance.WorkingHours
                };
                _appDbContext.Attendances.Add(attendances);
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
       public async Task<IEnumerable<Attendance>> GetAllAttendance()
        {
            try
            {
                var result = await _appDbContext.Attendances.ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Attendance> GetAttendancebyId(string Empid)
        {
            try
            {
                var result = await _appDbContext.Attendances.FindAsync(Empid);
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateAttendance(Attendance attendance)
        {
            try
            {
             _appDbContext.Attendances.Update(attendance);
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
       public async Task<bool> DeleteAttendance(string Empid)
        {
            try
            {
                if(_appDbContext.Attendances == null)
                {
                    return false;
                }
                var data = await _appDbContext.Attendances.FindAsync(Empid);
                if(data == null)
                {
                    return false;
                }
                _appDbContext.Attendances.Remove(data);
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
