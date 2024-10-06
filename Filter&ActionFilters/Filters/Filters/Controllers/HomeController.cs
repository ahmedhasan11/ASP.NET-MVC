using Filters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Filters.Controllers
{
    //The HandleErrorAttribute class is a
    //built-in exception filter class that renders the Error.cshtml by default
    //when an unhandled exception occurs

    //The [HandleError] filter is applied globally in the MVC application
    //by default in every MVC application
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        public ActionResult Index()
        {
            //throw exception for demo
            throw new Exception("This is unhandled exception");

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}