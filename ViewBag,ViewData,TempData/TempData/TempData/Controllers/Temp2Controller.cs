using Microsoft.AspNetCore.Mvc;

namespace TempData.Controllers
{
    public class Temp2Controller : Controller
    {
        ///The following transfers data from an action method to a view.
        public ActionResult Index()
        {
            TempData["name"] = "Bill";

            return View();
        }

        public ActionResult About()
        {
            //the following throws exception as TempData["name"] is null 
            //because we already accessed it in the Index.cshtml view
            //name = TempData["name"].ToString(); 

            return View();
        }

        public ActionResult Contact()
        {
            //the following throws exception as TempData["name"] is null 
            //because we already accessed it in the Index.cshtml view
            //name = TempData["name"].ToString(); 

            return View();
        }
    }
}
