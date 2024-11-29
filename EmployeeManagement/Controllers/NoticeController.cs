using BussinessAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAccessLayer;

namespace EmployeeManagement.Controllers
{
    public class NoticeController : Controller
    {
       private readonly INoticeServices _noticeServices;
        public NoticeController(INoticeServices noticeServices)
        {
            _noticeServices = noticeServices;
        }
        [HttpGet]
        public ActionResult AddNotice() {
            return View();
                }
        [HttpPost]
        public async Task<IActionResult> AddNotice(Notice notice)
        {
            try
            {
                if (ModelState.IsValid) { 
                var result = await _noticeServices.AddNotice(notice);
                    if (result)
                    {
                        return RedirectToAction("AddNotice");
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

        public async  Task<IActionResult> GetAllNotices()
        {
            try
            {
                var result = await _noticeServices.GetAllNoticeList();
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> GetNoticeById(int id)
        {
            try
            {       
                var result = await _noticeServices.GetNoticeById(id);
                    return View(result);                               
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNotice(int id)
        {
            try
            {
                var result = await _noticeServices.GetNoticeById(id);
                return View(result);
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotice(Notice notice)
        {
            try
            {
                var result = await _noticeServices.UpdateNotice(notice);
                return RedirectToAction("GetAllNotices");    
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> DeleteNotice(int id)
        {
            try
            {
                var result = await _noticeServices.DeleteNotice(id);
                return RedirectToAction("GetAllNotices");
            }
            catch
            {
                throw;
            }
        }
    }
}
