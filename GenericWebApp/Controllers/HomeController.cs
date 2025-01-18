using GenericWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenericWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(GenericWebApp.BLL.NPI.Registry.GetProviderList(new BLL.NPI.RegistrySearchDTO() { state = "CA", city = "LA" }));
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