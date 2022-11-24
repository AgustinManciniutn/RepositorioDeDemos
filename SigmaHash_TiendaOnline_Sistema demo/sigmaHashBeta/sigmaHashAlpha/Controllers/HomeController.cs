using Microsoft.AspNetCore.Mvc;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using System.Diagnostics;

namespace sigmaHashAlpha.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpContextAccessor context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor _context)
        {
            _logger = logger;
            context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult ListEditor()
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