using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedMVCApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedMVCApplication.Controllers
{

    public class UserController : Controller
    {
        private static Users _users = new Users();
        public ActionResult Index()
        {
            return View(_users.UserList);
        }

        //Action for UserAdd View 
        [HttpGet]
        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserModels userModel)
        {
            _users.CreateUser(userModel);
            return View("Index", _users.UserList);
        }

        //Action for Details View 
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_users.UserList.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Details()
        {
            return View("Index", _users.UserList);
        }

        //Action for Edit View 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_users.UserList.FirstOrDefault(x => x.Id == id));
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
            return View(_users.UserList.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(UserModels userModel)
        {
            _users.DeleteUser(userModel);
            return View("Index", _users.UserList);
        }
        
    }
}
