﻿
using System.Collections.Generic;
using System.Web.Mvc;
using Web_TP2.Models;

namespace Web_TP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if ((bool)Session["login"])
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            if ((bool)Session["login"])
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if ((bool)Session["login"])
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Log()
        {
            string user = Request.Form["username"];
            string pass = Request.Form["password"];

            UserSerializer s = new UserSerializer();
            List<User> listUsers = s.Read(Server.MapPath("~") + "users.txt");

            bool loginCorrect = false;
            foreach (User u in listUsers)
            {
                if (user == u.Log && pass == u.Pass) loginCorrect = true;
            }
            if (loginCorrect)
            {
                Session["login"] = true;
                return View("index");
            }
            else
            {
                return View("Login");
            }
        }
    }
}