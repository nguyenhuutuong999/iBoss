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
           
            return View(_admin.getAll());
        }
        public IActionResult aaaa()
        {

            return View(_admin.getAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.getPhongBan = _admin.getAllPhongBan();
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
        public IActionResult Details(int id)
        {
           
            return View(_admin.Detail(id));
        }

    }
}