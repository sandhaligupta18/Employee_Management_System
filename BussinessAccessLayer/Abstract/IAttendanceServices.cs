using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IAttendanceServices
    {
        public Task<bool> CreateAttendance(Attendance attendance);
        public Task<IEnumerable<Attendance>> GetAllAttendance();
        public Task<Attendance> GetAttendancebyId(string Empid);
        public Task<bool> UpdateAttendance(Attendance attendance);
        public Task<bool> DeleteAttendance(string Empid);

    }
}
