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
        public IActionResult Index()
        {
            ViewBag.Current = "human";
            return View(_manageHuman.getAll());
            
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