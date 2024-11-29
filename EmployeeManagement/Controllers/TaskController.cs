using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;
using NuGet.Versioning;

namespace EmployeeManagement.Controllers
{
    public class TaskController : Controller
    {
        private readonly  ITaskServices _taskServices;
        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(Tasks tasks)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _taskServices.AddTask(tasks);
                    return RedirectToAction("GetAllTasks");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _taskServices.GetAllTask();
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetTaskById(string Id)
        {
            try
            {
                var result = await _taskServices.GetTaskById(Id);
                return View(result);
            }
            catch {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTask(string Id)
        {
            try
            {
                var result = await _taskServices.GetTaskById(Id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
       public async Task<IActionResult> UpdateTask(Tasks tasks)
        {
            try
            {
                var result = await _taskServices.UpdateTask(tasks);
                return RedirectToAction("GetAllTask");
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> DeleteTask(string Id)
        {
            try
            {
                var result = await _taskServices.DeleteTask(Id);
                return RedirectToAction("GetAllTask");
            }
            catch
            {
                throw;
            }
        }
    }
}
