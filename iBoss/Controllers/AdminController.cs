using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBoss.Application.Admin;
using iBoss.Application.Human;
using iBoss.Models.Entities.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace iBoss.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }
        public IActionResult Index()
        {
            ViewBag.Current = "home";
            return View(_admin.getAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.getPayRate = _admin.getAllPayrate();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ModelViewAdmin model)
        {
            if (ModelState.IsValid)
            {
                _admin.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _admin.Detail(id);
            ViewBag.getPayRate = _admin.getAllPayrate();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ModelViewAdmin model)
        {
            if (ModelState.IsValid)
            {
                _admin.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {

            return View(_admin.Detail(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _admin.Detail(id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _admin.Delete(id);
            return RedirectToAction("Index");

        }

    }
}