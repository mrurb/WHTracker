using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WHTracker.Models;
using WHTracker.Services;

namespace WHTracker.Controllers
{
    public class HomeController : Controller
    {

        public HomeController( )
        {
        }

        public IActionResult Index(string ACString, string DMString, string DateString, string SortOrder)
        {
            ViewData["ACString"] = ACString;
            ViewData["DMString"] = DMString;
            ViewData["DateString"] = DateString;
            ViewData["SortOrder"] = SortOrder;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
