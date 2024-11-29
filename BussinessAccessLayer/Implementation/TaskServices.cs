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
    public class TaskServices : ITaskServices
    {
        private readonly AppDb_Context _appDbContext;
        public TaskServices(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddTask(Tasks task)
        {
            try
            {
                Tasks tasks = new() { 
                Empid = task.Empid,
                AssignedEmpName = task.AssignedEmpName,
                ProjectId = task.ProjectId,
                ProjectName = task.ProjectName,
                TaskTittle = task.TaskTittle,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = task.Status,   
                };
                _appDbContext.Task.Add(tasks);
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

       public async Task<bool> DeleteTask(string Empid)
        {
            try
            {
                if (_appDbContext.Task == null) { 
                return false;   
                }
                var data = await _appDbContext.Task.FindAsync(Empid);
                if (data == null) {
                    return false;
                }
                _appDbContext.Task.Remove(data);
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

       public async Task<IEnumerable<Tasks>> GetAllTask()
        {
            try
            {
                var data = await _appDbContext.Task.ToListAsync();
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tasks> GetTaskById(string Empid)
        {
            try
            {
                var data = await _appDbContext.Task.FindAsync(Empid );
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateTask(Tasks task)
        {
            try
            {
                _appDbContext.Task.Update(task);
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
