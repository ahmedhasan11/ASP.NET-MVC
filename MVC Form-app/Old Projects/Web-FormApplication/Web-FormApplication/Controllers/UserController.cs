using Microsoft.AspNetCore.Mvc;
using Web_FormApplication.Models;

namespace Web_FormApplication.Controllers
{
    public class UserController : Controller
    {
        private static User _user = new User(); 
        public IActionResult Index()
        {
            return View(_user.UserList);
        }
        [HttpGet]
        public ActionResult UserAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserAdd(UserModel um)
        {
            _user.UserAdd(um);

            return View ("Index" , _user.UserList);

        }
        [HttpGet]
        public ActionResult UserUpdate(int id)
        {
            return View(_user.UserList.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        public ActionResult UserUpdate(UserModel um)
        {
            _user.UserUpdate(um);
            return View("Index", _user.UserList);
        }
        [HttpGet]
        public ActionResult UserDetails(int id)
        {
            return View(_user.UserList.FirstOrDefault(x => x.id == id));
        }
        [HttpPost]
        public ActionResult UserDetails()
        {
            return View("Index", _user.UserList);
        }
        public ActionResult UserDelete(int id)
        {
            return View(_user.UserList.FirstOrDefault(x => x.id == id));
        }
        public ActionResult UserDelete(UserModel umm)
        {
            _user.UserDelete(umm);
            return View("Index", _user.UserList);
        }
    }
}
