using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface ITaskServices
    {
        public Task<bool> AddTask(Tasks task) ;
        public Task<IEnumerable<Tasks>> GetAllTask();
        public Task<Tasks> GetTaskById(string Empid);
        public Task<bool> UpdateTask(Tasks task);
        public Task<bool> DeleteTask(string Empid);
    }
}
