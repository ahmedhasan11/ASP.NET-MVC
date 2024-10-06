using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace TempData.Controllers
{
    public class Temp3Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (TempData.ContainsKey("name"))
                name = TempData["name"].ToString(); // returns "Bill" 

            return View();
        }

        public ActionResult Contact()
        {
            //the following throws exception as TempData["name"] is null 
            //because we already accessed it in the About() action method
            //name = TempData["name"].ToString(); 

            return View();
        }dfhghghg
    }
}
