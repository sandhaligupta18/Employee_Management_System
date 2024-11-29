using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface INoticeServices
    {
        public Task<bool> AddNotice(Notice notice);
        public Task<IEnumerable<Notice>> GetAllNoticeList();
        public Task<Notice> GetNoticeById(int id);
        public Task<bool> UpdateNotice(Notice notice);
        public Task<bool> DeleteNotice(int id);


    }
}
