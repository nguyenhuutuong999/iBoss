using iBoss.Application.Human;
using iBoss.Models.Entities.Human;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iBoss.Controllers
{
    public class HumanController : Controller
    {
        private readonly IManageHuman _manageHuman;
        public HumanController(IManageHuman manageHuman)
        {
            _manageHuman = manageHuman;
        }
        [Route("human")]
        public IActionResult Index()
        {
            var model = _manageHuman.getAll();
            ViewBag.Current = "human";
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "User");
            }
            else if (HttpContext.Session.GetString("Role").ToString() == "Admin")
            {
                return View(model);
            }
            else if (HttpContext.Session.GetString("Role").ToString() != "Human")
            {
                return RedirectToAction("Error");
            }
            var value = _manageHuman.getGender();

            ViewBag.Male = value.Item1;
            ViewBag.Female = value.Item2;

            ViewBag.Role = HttpContext.Session.GetString("Role");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            
            return View(model);
            
        }

        public IActionResult Detail(int id)
        {
            var model = _manageHuman.Detail(id);
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    //ViewBag.getPhongBanEdit = _manageHuman.getAllPhongBan();

        //    var model = _manageHuman.Detail(id);
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Edit(ModelViewHuman request)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _manageHuman.Update(request);
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Create()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(ModelViewHuman request)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _manageHuman.Add(request);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        // [HttpGet]
        // public IActionResult Delete(int id)
        // {
        //     var model = _manageHuman.Detail(id);
        //     return View(model);
        // }
        // [HttpPost, ActionName("Delete")]
        // public IActionResult ConfirmDelete(int id)
        // {
        //     _manageHuman.Delete(id);
        //     return RedirectToAction("index");
        // }

    }
}