
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
                FilmSerializer.AddToUserList(new Film("le Film"), (string)Session["user"], Server.MapPath("~") + "playlists.txt");
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

            List<User> listUsers = UserSerializer.Read(Server.MapPath("~") + "users.txt");

            foreach (User u in listUsers)
            {
                if (user == u.Log && pass == u.Pass)
                {
                    Session["login"] = true;
                    Session["user"] = u.Log;
                    Session["admin"] = u.Admin;
                };
            }

            if ((bool)Session["login"])
            {
                return View("index");
            }
            else
            {
                return View("Login");
            }
        }
    }
}