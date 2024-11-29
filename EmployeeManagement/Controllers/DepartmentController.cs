using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
       
        private readonly IDepartmentServices _departmentServices;
        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Departments department)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result =await _departmentServices.CreateDepartment(department);
                    if (result) { 
                    return RedirectToAction("CreateDepartment");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var result =await _departmentServices.GetAllDepartments();
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(int Id)
        {
            try
            {
             var result = await _departmentServices.GetDepartmentById(Id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var result =await _departmentServices.GetDepartmentById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(Departments department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result =await _departmentServices.UpdateDepartment(department);
                    if (result)
                    {
                        return RedirectToAction("GetAllDepartment");
                    }
                }
                return View();
            }
            catch
            {
                throw;
            }
        }
      
        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _departmentServices.DeleteDepartment(id);
                    return RedirectToAction("GetAllDepartment");
                }
                return View();
            }
            catch
            {
                throw;
            }
        }
    }
}

