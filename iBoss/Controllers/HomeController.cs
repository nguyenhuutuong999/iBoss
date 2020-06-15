using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iBoss.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Data;
using iBoss.Models.Entities.Payroll;
using iBoss.Application.Human;
using iBoss.Models.Entities.Human;

namespace iBoss.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManageHuman _manageHuman;

        public HomeController(ILogger<HomeController> logger, IManageHuman manageHuman)
        {
            _logger = logger;
            _manageHuman = manageHuman;
            this.ViewData["LayoutViewModel"] = "aaa";

        }
        

        [Route("home")]
        public IActionResult Index()
        {
            ViewBag.Current = "home";
            return View();
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search()
        {

            ModelViewHuman getModel;
            var keyWord = Request.Query["search"];
            
            ViewBag.key = keyWord;
            try
            {
                 getModel = _manageHuman.Detail(Int32.Parse(keyWord));
            }
            catch(Exception e)
            {
                @ViewBag.Search = "Not Found";
                return View(null);
            }
                @ViewBag.Search = "Result";

            return View(getModel);
        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
