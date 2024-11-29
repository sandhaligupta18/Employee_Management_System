using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        // GET: EmployeeController
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDetailsView employeeDetailsView)
        {
            try
            {
                if (ModelState.IsValid) { 
                
                var result = await _employeeServices.AddEmployee(employeeDetailsView);
                    if (result)
                    {
                        return RedirectToAction("AddEmployee");
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

        public async Task<IActionResult> GetAllEMployess()
        {
            try
            {
                var data = await _employeeServices.GetEmployee();
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(string Id)
        {
            var result = await _employeeServices.GetEmployeeById(Id);
            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> UpdateEmployeeDetail(string id)
        {
            var values = await _employeeServices.GetEmployeeById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeDetail(EmployeeDetails employeeDetails)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result = await _employeeServices.UpdateEmployeeDetail(employeeDetails);
                    return RedirectToAction("GetAllEMployess");
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
        [HttpGet]
        public async Task<IActionResult> DeleteEmployeeDetail(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _employeeServices.DeleteEmployeeDetail(id);
                    return RedirectToAction("GetAllEMployess");
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
