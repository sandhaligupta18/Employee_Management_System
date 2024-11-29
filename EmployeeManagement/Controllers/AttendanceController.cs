using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceServices _attendanceServices;
        public AttendanceController(IAttendanceServices attendanceServices)
        {
            _attendanceServices = attendanceServices;
        }

        public IActionResult CreateAttendance()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAttendance(Attendance attendance)
        {
            try
            {
                if (ModelState.IsValid) {
                    var result = await _attendanceServices.CreateAttendance(attendance);
                    if (result)
                    {
                        return RedirectToAction("CreateAttendance");
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
        
        public async Task<IActionResult> GetAllAttendances()
        {
            try
            {
                var result =await _attendanceServices.GetAllAttendance();
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAttendancebyId(string id)
        {
            try
            {
                var result = await _attendanceServices.GetAttendancebyId(id);
                return View(result);    
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAttendance(string id)
        {
            try
            {
                var result = await _attendanceServices.GetAttendancebyId(id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAttendance(Attendance attendance)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result = await _attendanceServices.UpdateAttendance(attendance);
                    if (result)
                    {
                        return RedirectToAction("GetAllAttendances");
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
        public async Task<IActionResult> DeleteAttendance(string id)
        {
            try
            {
                var result = await _attendanceServices.DeleteAttendance(id);
                if (result)
                {
                    return RedirectToAction("GetAllAttendances");
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
