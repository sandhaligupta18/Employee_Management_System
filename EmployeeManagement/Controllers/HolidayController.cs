using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class HolidayController : Controller
    {
        private readonly IHolidaysServices _holidaysServices;
        public HolidayController(IHolidaysServices holidaysServices)
        {
            _holidaysServices = holidaysServices;
        }
        [HttpGet]
       public IActionResult AddHolidays()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHolidays(Holidays holidays) {
            try {
                if (ModelState.IsValid) { 
                var result =await _holidaysServices.AddHolidays(holidays);
                    if (result)
                    {
                        return RedirectToAction("AddHolidays");
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
        public async Task<IActionResult> GetAllHolidays()
        {
            try
            {
                var result = await _holidaysServices.GetAllHoliday();
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetHolidaysById(int id)
        {
            try
            {
                var data = await _holidaysServices.GetHolidaysById(id);
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHolidays(int id)
        {
            try
            {
                var data = await _holidaysServices.GetHolidaysById(id);
                return View(data);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHolidays(Holidays holidays)
        {
            try
            {
                var result = await _holidaysServices.UpdateHolidays(holidays);
                if (result)
                {
                    return RedirectToAction("GetAllHolidays");
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
        public async Task<IActionResult> DeleteHolidays(int id)
        {
            try
            {
             var result = await _holidaysServices.DeleteHolidays(id);
                if (result)
                {
                    return RedirectToAction("GetAllHolidays");
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

    }
}
