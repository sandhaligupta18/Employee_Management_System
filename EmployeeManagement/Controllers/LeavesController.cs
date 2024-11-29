using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class LeavesController : Controller
    {
        private readonly ILeavesServices _leavesServices;
        public LeavesController(ILeavesServices leavesServices)
        {
            _leavesServices = leavesServices;
        }
        [HttpGet]
        public IActionResult AddLeaves() {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddLeaves(Leaves leaves)
        {
            try
            {
                if (ModelState.IsValid) { 
                 var result = await _leavesServices.AddLeaves(leaves);
                    if (result)
                    {
                        return RedirectToAction("AddLeaves");
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
        public async Task<IActionResult> GetAllLeaves()
        {
            try
            {
                var data = await _leavesServices.GetAllLeaves();
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetLeavesById(string id)
        {
            var data = await _leavesServices.GetLeavesById(id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLeaves(string id)
        {
            var data = await _leavesServices.GetLeavesById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLeaves(Leaves leaves)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = await _leavesServices.UpdateLeaves(leaves);
                    if (data)
                    {
                        return RedirectToAction("AddLeaves");
                    }
                    else{
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
        public async Task<IActionResult> DeleteLeaves(string id)
        {
            try
            {
                var data = await _leavesServices.DeleteLeaves(id);
                return View(data);
            }
            catch
            {
                throw;
            }
        }
    }
}
