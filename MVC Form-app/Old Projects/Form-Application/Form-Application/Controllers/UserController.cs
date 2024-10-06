using Form_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form_Application.Controllers
{
    public class UserController : Controller
    {
        //first thing to do is creating object from users class model 
        private static Users _user = new Users();
        public IActionResult Index()
        {
            return View(_user.UserList);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateUser(UserModel usrmod)
        {
            _user.CreateUser(usrmod);
            return View("Index" , _user.UserList);
        }

        [HttpGet]

        public ActionResult UpdateUser(int id)
        {
            var user = _user.UserList.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            //FirstOrDefault(...): This is a LINQ method
            //that returns the first element in a collection that satisfies a given condition
            //x.id == id the condition
            // x is each individual object in the list
            return View(user);
        }

        [HttpPost]

        public ActionResult UpdateUser(UserModel usrmod)
        {
            _user.UpdateUser(usrmod);
            return View("Index" , _user.UserList);
        }

        [HttpGet]

        public ActionResult GetUser(int id)
        {
            return View(_user.UserList.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]

        public ActionResult GetUser()
        {           
            return View("Index" , _user.UserList);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View(_user.UserList.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]

        public ActionResult DeletUser(UserModel usermodel)
        {
            _user.DeleteUser(usermodel);
            return View("Index" , _user.UserList);
        }
    }
}
