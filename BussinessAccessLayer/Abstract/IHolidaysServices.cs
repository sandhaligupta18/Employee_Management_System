using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IHolidaysServices
    {
        public Task<bool> AddHolidays(Holidays holidays);
        public Task<IEnumerable<Holidays>> GetAllHoliday();
        public Task<Holidays> GetHolidaysById(int id);
        public Task<bool> UpdateHolidays(Holidays holidays);
        public Task<bool> DeleteHolidays(int id);


    }
}
