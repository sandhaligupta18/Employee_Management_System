using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationServices _designationServices;
        public DesignationController(IDesignationServices designationServices)
        {
          _designationServices = designationServices;
        }
        [HttpGet]
       public IActionResult AddDesignation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDesignation(Designation designation)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result = await _designationServices.AddDesignation(designation);
                    if (result)
                    {
                        return RedirectToAction("GetAllDesignations");
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
        public  async Task<IActionResult> GetAllDesignations()
        {
            try
            {
                var result = await _designationServices.GetDesignations();
                return View(result);    
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetDesignationById(int id)
        {
            try
            {
                var result = await _designationServices.GetDesignationById(id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDesignation(int id)
        {
                var result = await _designationServices.GetDesignationById(id);
               return  View(result);  
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDesignation(Designation designation)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result = await  _designationServices.UpdateDesignation(designation);
                    if (result)
                    {
                        return RedirectToAction("GetAllDesignations");
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

       public async Task<IActionResult> DeleteDesignation(int id)
        {
            try
            {
                if (ModelState.IsValid) {

                    var result = await _designationServices.DeleteDesignation(id);
                    return RedirectToAction("GetAllDesignations");
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
