using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WhatCanICook.Models;

namespace WhatCanICook.Controllers
{
   
    public class HomeController : Controller
    {
        WhatCanICookDBEntities entity = new WhatCanICookDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Account()
        {

            return View();
        }

        public ActionResult DisplayUserInfo()
        {
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Recipe()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            var userTemp = entity.Users.FirstOrDefault(u => u.user_email == user.Email);
            if (userTemp != null)
            {
                userTemp.user_email = user.Email;
                userTemp.user_firstName = user.FirstName;
                userTemp.user_lastName = user.LastName;
                userTemp.user_password = user.Password;
                userTemp.user_foodType = user.FoodPreferance;
                entity.SaveChanges();

                WebApplication1.Controllers.AccountController.userModel.Email = user.Email;
                WebApplication1.Controllers.AccountController.userModel.FirstName = user.FirstName;
                WebApplication1.Controllers.AccountController.userModel.LastName = user.LastName;
                WebApplication1.Controllers.AccountController.userModel.Password = user.Password;
                WebApplication1.Controllers.AccountController.userModel.FoodPreferance = user.FoodPreferance;
                // It will redirect to
                // the Read method
                return RedirectToAction("Account");
            }
            else
                return View();



        }
    }
}