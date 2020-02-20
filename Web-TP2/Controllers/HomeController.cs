
using System.Web.Mvc;
using Web_TP2.Models;

namespace Web_TP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Login l = new Login("ben","123");
            Serializer<Login> s = new Serializer<Login>();
            s.Serialize(l, HttpContext.Current.Server.MapPath(@"~/xyz.txt"));
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
    }
}