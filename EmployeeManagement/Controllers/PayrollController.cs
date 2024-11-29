using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class PayrollController : Controller
    {

        private readonly IPayRollServices _payRollServices;
        public PayrollController(IPayRollServices payRollServices)
        {
            _payRollServices = payRollServices;
        }
        [HttpGet]
        public ActionResult AddPayroll()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPayroll(Payroll payroll)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result = await _payRollServices.AddPayroll(payroll);
                    return RedirectToAction("AddPayroll");
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
        public async Task<IActionResult> GetALlPayRolls()
        {
            try
            {
                var data = await _payRollServices.GetALlPayroll();
                return View(data);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IActionResult> GetPayroll(string Id)
        {
            try
            {
                var result = await _payRollServices.GetPayroll(Id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePayroll(string id)
        {
            try
            {
                var result = await _payRollServices.GetPayroll(id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePayroll(Payroll payroll)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _payRollServices.UpdatePayroll(payroll);
                    return RedirectToAction("AddPayroll");
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
        public async Task<IActionResult> DeletePayroll(string id)
        {
            try
            {
                var result = await _payRollServices.DeletePayroll(id);
                return RedirectToAction("AddPayroll");
            }
            catch
            {
                throw;
            }
        }

    }
}
