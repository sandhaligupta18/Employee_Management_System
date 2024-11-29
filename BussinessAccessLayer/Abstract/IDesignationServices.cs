using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
     public interface IDesignationServices
    {
        public Task<bool> AddDesignation(Designation designation);
        public Task<IEnumerable<Designation>> GetDesignations();
        public Task<Designation> GetDesignationById(int id);
        public Task<bool> UpdateDesignation(Designation designation);
        public Task<bool> DeleteDesignation(int id);
    }
}
