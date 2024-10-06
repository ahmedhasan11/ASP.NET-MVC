using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System;

namespace TempData.Controllers
{
    public class TempController : Controller
    {
        //TempData is used to transfer data from view to controller,
        //controller to view,
        //or from one action method to another action method of the same or a different controller.
        // TempData stores the data temporarily and automatically removes it after retrieving a value


      ///  how to transfer data from one action method to another using TempData.


        public ActionResult Index()
        {
            TempData["name"] = "Bill";

            return View();
        }

        public ActionResult About()
        {
            string name;

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
        }
    }
}
