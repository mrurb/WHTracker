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
        private readonly ILogger<HomeController> _logger;
        private readonly AggregateCacheManagerService aggregateCacheManagerService;

        public HomeController(ILogger<HomeController> logger, AggregateCacheManagerService aggregateCacheManagerService)
        {
            _logger = logger;
            this.aggregateCacheManagerService = aggregateCacheManagerService;
        }

        public async Task<IActionResult> IndexAsync()
        {
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
