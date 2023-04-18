using BitcoinPaymentIntegrationDemo.Components;
using BitcoinPaymentIntegrationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitcoinPaymentIntegrationDemo.Controllers
{
    public class HomeController : Controller
    {
        public const string NAME = "Home";
        public const int PRICE = 15;

        private readonly ILogger<HomeController> _logger;
        private readonly InvoiceComponent _invoiceComponent;

        public HomeController(
            ILogger<HomeController> logger
        )
        {
            _logger = logger;
            _invoiceComponent = new InvoiceComponent();
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
        public async Task<IActionResult> Pay(ProductSelectionModel productSelectionModel)
        {
            var invoiceModel = await _invoiceComponent.GetInvoiceAsync(productSelectionModel.Amount * PRICE);

            return View(invoiceModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
