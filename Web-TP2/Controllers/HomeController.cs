
using System.Collections.Generic;
using System.Web.Mvc;
using Web_TP2.Models;

namespace Web_TP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            Login l = new Login("ben","123");
            Serializer s = new Serializer();
            s.Serialize(l, Server.MapPath("~") + "xyz.txt");
            */
            Serializer s = new Serializer();
            ViewBag.liste = s.Read(Server.MapPath("~")+ "xyz.txt");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Accueil()
        {
            return View();

        }

        public ActionResult Nouveaute()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            string user = Request.Form["username"];
            string pass = Request.Form["password"];

            Serializer s = new Serializer();
            List<object> listUsers = s.Read(Server.MapPath("~") + "users.txt");

            bool loginCorrect = false;
            foreach (Login u in listUsers) {
                if (user == u.Log && pass == u.Pass) loginCorrect = true;
            }
            if (loginCorrect) {

                return View("index");
            }
            else {
                return View("Accueil");
            }
        }
    }
}