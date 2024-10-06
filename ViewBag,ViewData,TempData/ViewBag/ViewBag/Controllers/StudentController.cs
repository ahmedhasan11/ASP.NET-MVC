using Microsoft.AspNetCore.Mvc;

namespace ViewBag.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
