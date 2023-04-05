using BitcoinPaymentIntegrationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitcoinPaymentIntegrationDemo.Controllers
{
    public class HomeController : Controller
    {
        public string NAME = "Home";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ProductSelectionModel model)
        {
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}