using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASampleWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogInformation("HomeController started.");
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index requested...");
            return View();
        }

        public IActionResult Error()
        {
            _logger.LogError("An error occured.");
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
