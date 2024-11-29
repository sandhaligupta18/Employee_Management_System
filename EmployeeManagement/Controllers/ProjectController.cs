using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectServices) {
          _projectServices = projectServices;
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddProject(Projects projects)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _projectServices.AddProject(projects);
                    return RedirectToAction("AddProject");
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
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var data = await _projectServices.GetAllProjects();
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetProjectByid(int Id)
        {
            try
            {
                var data = await _projectServices.GetProjectByid(Id);
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProjects(int Id)
        {
            try
            {
                var data = await _projectServices.GetProjectByid(Id);
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProjects(Projects projects)
        {
            try
            {
                var data = await _projectServices.UpdateProjects(projects);
                return RedirectToAction("AddProject");
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> DeleteProject(int Id)
        {
            try
            {
                var data = await _projectServices.DeleteProject(Id);
                return RedirectToAction("AddProject");
            }
            catch
            {
                throw;
            }
        }

    }
}
