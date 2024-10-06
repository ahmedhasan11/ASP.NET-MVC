using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class UserController : Controller
    {
        private static User _user = new User();
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
        public ActionResult CreateUser(UserModel um)
        {
            _user.CreateUser(um);
            return View( "index" , _user.UserList);
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var user = _user.UserList.FirstOrDefault(x => x.id == id);
          //  if (user == null)
           // {
                //return NotFound();
           // }
            //FirstOrDefault(...): This is a LINQ method
            //that returns the first element in a collection that satisfies a given condition
            //x.id == id the condition
            // x is each individual object in the list
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserModel um)
        {
            _user.UpdateUser(um);

            return View("index" , _user.UserList );
        }


        [HttpGet]
        public ActionResult GetDetails(int id)
        {
            return View (_user.UserList.FirstOrDefault(x => x.id==id) );
        }
        [HttpPost]
        public ActionResult GetDetails()
        {
            return View ("index" , _user.UserList);
        }



        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View (_user.UserList.FirstOrDefault( x => x.id==id));
            
        }
        [HttpPost]
        public ActionResult DeleteUser(UserModel um)
        {
            _user.DeleteUser(um);
            return View("index" ,_user.UserList);

        }
    }
}
