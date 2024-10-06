using Microsoft.AspNetCore.Mvc;
using MVC_Advanced_App.Models;

namespace MVC_Advanced_App.Controllers
{
    public class UserController : Controller
    {
        private static Users _users = new Users();
        public IActionResult Index()
        {
            return View(_users.UserList);
        }
        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAdd(UserModels usermodel) 
        {
            _users.CreateUser(usermodel);
            return View( "index" , _users.UserList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_users.UserList.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        public ActionResult Details()
        {
            return View("Index", _users.UserList);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_users.UserList.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        public ActionResult Edit(UserModels userModel)
        {
            _users.UpdateUser(userModel);
            return View("Index", _users.UserList);
        }

        //Action for Delete View 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_users.UserList.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        public ActionResult Delete(UserModels userModel)
        {
            _users.DeleteUser(userModel);
            return View("Index", _users.UserList);
        }
       
    }
}
