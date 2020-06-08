using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBoss.Application.User;
using iBoss.Models.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBoss.Controllers
{
    public class UserController : Controller
    {
        private readonly  IManageUser _manageUser;
        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[Route("login")]
        [HttpGet]
        public IActionResult Login()
        {   if(Request.Cookies["LastLoggedInTime"] != null)
            ViewBag.LTLD = Request.Cookies["LastLoggedInTime"].ToString();
            return View();
        }
        //[Route("login")]
        [HttpPost]
        public IActionResult Login(USER model)
        {
            USER user = _manageUser.Login(model);
            if(user == null)
            {
                ViewBag.Error = "Wrong Username or Password";
                return View();
            }
            //save session
            HttpContext.Session.SetString("Username", user.USERNAME);
            HttpContext.Session.SetString("Role", user.ROLE);
            HttpContext.Session.SetString("Name", user.NAME);

            //get time Login in
            Response.Cookies.Append("LastLoggedInTime", DateTime.Now.ToString());

            if (HttpContext.Session.GetString("Role") == "Admin"){
                return RedirectToAction("Index", "Admin");
            }
            else if (HttpContext.Session.GetString("Role") == "Payroll")
            {
                return RedirectToAction("Index", "Payroll");
            }
            else if (HttpContext.Session.GetString("Role") == "Human")
            {
                return RedirectToAction("Index", "Human");
            }
            return View();

        }
        // save user information in session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
