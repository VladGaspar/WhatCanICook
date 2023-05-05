using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatCanICook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Your application description page.";

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
    }
}