using Log.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Log.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //instead of passing the parameter that in the Constructor here
        //we can do this :

      //  public HomeController(ILoggerFactory logFactory)
       // {
      //      _logger = logFactory.CreateLogger<HomeController>();
      //  }


      //and will give us same result
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //logging in controller
            _logger.LogInformation("Log message in the Index() method");
            return View();
        }

        public IActionResult Privacy()
        {
            //logging in controller
            _logger.LogInformation("Log message in the About() method");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}