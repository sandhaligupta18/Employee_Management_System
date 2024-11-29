using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface ILeavesServices
    {
        public Task<bool> AddLeaves(Leaves leaves);
        public Task<IEnumerable<Leaves>> GetAllLeaves();
        public Task<Leaves> GetLeavesById(string Empid);
        public Task<bool> UpdateLeaves(Leaves leaves);
        public Task<bool> DeleteLeaves(string Empid);

    }
}
