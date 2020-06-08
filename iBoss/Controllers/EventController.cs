using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBoss.Application.Human;
using iBoss.Application.Payroll;
using iBoss.Models.Entities.Human;
using Microsoft.AspNetCore.Mvc;
using iBoss.Models.Entities.Payroll;
using Microsoft.AspNetCore.Http;

namespace iBoss.Controllers
{
    public class EventController : Controller
    {
        private readonly IManagePayroll _managePayroll;
        private readonly IManageHuman _manageHuman;


        public EventController(IManagePayroll nanagePayroll, IManageHuman manageHuman)
        {
            _managePayroll = nanagePayroll;
            _manageHuman = manageHuman;
        }
        [Route("event")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "User");
            }
           
            ViewBag.Role = HttpContext.Session.GetString("Role");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Current = "event";
            return View();
        }
        [HttpPost]
        public IActionResult Birthday(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
               
                var nv = _manageHuman.getBirthDayNhanVien(id);
               
                return Json(nv);
            }
          
        }
        
       
        [HttpPost]
        public IActionResult Inform(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

                var nv = _manageHuman.getBirthDayNhanVien(id);

                return Json(nv);
            }

        }


    }
}