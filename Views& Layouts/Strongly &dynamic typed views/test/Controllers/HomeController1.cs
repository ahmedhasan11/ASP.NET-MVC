using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace test.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public class Blog
        {
            public string Name;
            public string URL;
        }
        private readonly List topBlogs = new List {
         new Blog { Name = "Joe Delage", URL = "http://tutorialspoint/joe/"},
         new Blog {Name = "Mark Dsouza", URL = "http://tutorialspoint/mark"},
         new Blog {Name = "Michael Shawn", URL = "http://tutorialspoint/michael"}
      };
        public ActionResult StonglyTypedIndex()
        {
            return View(topBlogs);
        }
        public ActionResult IndexNotStonglyTyped()
        {
            return View(topBlogs);
        }
    }
}
