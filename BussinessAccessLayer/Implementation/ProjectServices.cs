using Azure.Core;
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
    public class ProjectServices:IProjectServices
    {
        private readonly AppDb_Context _appDbContext;
        public ProjectServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddProject(Projects projects)
        {
            try
            {
                Projects project = new() { 
                ProjectName = projects.ProjectName,
                Status = projects.Status,
                StartDate = projects.StartDate,
                EndDate = projects.EndDate,
                };
               _appDbContext.Project.Add(project);
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

        public async Task<bool> DeleteProject(int Projectid)
        {
            try
            {
                if (_appDbContext.Project == null) {
                    return false;
                }
                var data = await _appDbContext.Project.FindAsync(Projectid);
                if(data == null){
return false;
                }
               _appDbContext.Project.Remove(data);
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

       public async Task<IEnumerable<Projects>> GetAllProjects()
        {
            try
            {
                var data = await _appDbContext.Project.ToListAsync();
                return data;
            }

            catch
            {
                throw;
            }
        }

        public async Task<Projects> GetProjectByid(int Projectid)
        {
            try
            {
                var data = await _appDbContext.Project.FindAsync(Projectid);
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateProjects(Projects projects)
        {
            try
            {
                _appDbContext.Project.Update(projects);
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
