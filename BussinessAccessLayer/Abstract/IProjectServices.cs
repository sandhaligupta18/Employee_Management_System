using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Abstract
{
    public interface IProjectServices
    {
        public Task<bool> AddProject(Projects projects);
        public Task<IEnumerable<Projects>> GetAllProjects();
        public Task<Projects> GetProjectByid(int Projectid);
        public Task<bool> UpdateProjects(Projects projects);
        public Task<bool> DeleteProject(int Projectid);

    }
}
