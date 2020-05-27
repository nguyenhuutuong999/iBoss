using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBoss.Application.Payroll;
using iBoss.Models.Entities.Payroll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iBoss.WebApp.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IManagePayroll _managePayroll;
        public PayrollController(IManagePayroll managePayroll)
        {
            _managePayroll = managePayroll;
        }
       
        //public IActionResult Index()
        //{
        //    ViewBag.Current = "payroll";
        //    return View(_managePayroll.getAll());
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(ModelViewPayroll request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _managePayroll.Add(request);
        //        return RedirectToAction("Index");
        //    }
           
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{

        //   var model = _managePayroll.ViewDetail(id);
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Edit(ModelViewPayroll request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _managePayroll.Update(request);
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Detail(int id)
        //{
        //    var model = _managePayroll.Detail(id);
        //        return View(model);

        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var model = _managePayroll.Detail(id);
        //    return View(model);

        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirm(int id)
        //{
        //    var model = _managePayroll.Delete(id);
        //    return RedirectToAction("Index");
        //}

     
        public IActionResult Index()
        {
            var model = _managePayroll.getAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _managePayroll.Detail(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.getPayRate = _managePayroll.getAllPayrate();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ModelViewPayroll request)
        {
            if (ModelState.IsValid)
            {
              _managePayroll.Add(request);
              return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.getPayRate = _managePayroll.getAllPayrate();
            var model = _managePayroll.ViewDetail(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ModelViewPayroll request)
        {
            if (ModelState.IsValid)
            {
                _managePayroll.Update(request);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _managePayroll.Detail(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
           var model = _managePayroll.Delete(id);
           return RedirectToAction("Index");
        }
    }

}