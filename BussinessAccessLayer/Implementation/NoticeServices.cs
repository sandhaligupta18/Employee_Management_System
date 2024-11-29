using BussinessAccessLayer.Abstract;
using DataAccessLayer.ApplicationDb_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implementation
{
    public class NoticeServices : INoticeServices
    {
        private readonly AppDb_Context _appDbContext;
        public NoticeServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddNotice(Notice notice)
        {
            try
            {
                Notice notices = new() { 
                Title = notice.Title,
                Description = notice.Description,
                CreatedDate = notice.CreatedDate,
                };
                _appDbContext.Notice.Add(notice);
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

        public async Task<bool> DeleteNotice(int id)
        {
            try
            {
                if(_appDbContext.Notice == null)
                {
                    return false;
                }
                var data = await _appDbContext.Notice.FindAsync(id);
                if (data == null) { 
                return false;
                }
                _appDbContext.Notice.Remove(data);
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

        public async Task<IEnumerable<Notice>> GetAllNoticeList()
        {
            try
            {
                var data = await _appDbContext.Notice.ToListAsync();
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Notice> GetNoticeById(int id)
        {
            try
            {
                var data = await _appDbContext.Notice.FindAsync(id);
                return data;
            }
            catch
            {
                throw;
            }
        }

       public async Task<bool> UpdateNotice(Notice notice)
        {
            try
            {
                _appDbContext.Notice.Update(notice);
                var data = await _appDbContext.SaveChangesAsync();
                if(data > 0)
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
