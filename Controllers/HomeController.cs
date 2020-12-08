using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ExampleApp.Models;

namespace ExampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;
        private IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IRepository repo, IConfiguration config)
        {
            _logger = logger;
            repository = repo;
            configuration = config;
        }

        public IActionResult Index()
        {
            ViewBag.Message = configuration["Message"] ?? "Essential Docker";
            return View(repository.Products);
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
