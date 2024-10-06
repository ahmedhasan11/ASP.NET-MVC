using Microsoft.AspNetCore.Mvc;

namespace mvc_tutorials_point.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;

            ViewBag.Greeting =
            hour < 12
            ? "Good Morning. Time is" + DateTime.Now.ToShortTimeString()
            : "Good Afternoon. Time is " + DateTime.Now.ToShortTimeString();
            return View();

          //  we are accessing the value of Greeting attribute
          //  of the ViewBag object using @ in the index.cshtml(view)
        }
    }
}
