using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WhatCanICook.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        
        WhatCanICookDBEntities entity = new WhatCanICookDBEntities();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // POST: Account
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.Users.Any(x => x.user_email == credentials.Email && x.user_password == credentials.Password);
            User u = entity.Users.FirstOrDefault(x => x.user_email == credentials.Email && x.user_password == credentials.Password);


            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.user_firstName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password is wrong");
            return View();

        }
        [HttpPost]
        public ActionResult SignUp(User userinfo)
        {
            entity.Users.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }



    }
}