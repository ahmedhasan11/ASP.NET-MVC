using Microsoft.AspNetCore.Mvc;
using MVC_Advanced_Project.Models;

namespace MVC_Advanced_Project.Controllers
{
    public class UserController : Controller
    {
        private static User _userlist =new User();
        public IActionResult Index()
        {
            return View(_userlist.UserList);
        }
        //add,edit,delete,details

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserModel um)
        {
            _userlist.AddUser(um);
            return View("Index",_userlist.UserList);

        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            //_userlist.UserList.FirstOrDefault(x => x.Id == id)

            return View(_userlist.UserList.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeleteUser(UserModel um)
        {
            _userlist.DeleteUser(um);
            return View("Index", _userlist.UserList);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            return View(_userlist.UserList.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult EditUser(UserModel um)
        {
            _userlist.EditUser(um);

            return View("Index", _userlist.UserList);
        }
        [HttpGet]
        public ActionResult DetailsUser(int id)
        {
            
           // _userlist.DetailsUser(id);

            return View(_userlist.UserList.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult DetailsUser()
        {

            return View("Index", _userlist.UserList);
        }
    }
}
