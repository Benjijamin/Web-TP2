using System.Collections.Generic;
using System.Web.Mvc;
using Web_TP2.Models;

namespace Web_TP2.Controllers
{
    public class FilmController : Controller
    {
        FilmSerializer s = new FilmSerializer();

        // GET api/<controller>
        public ActionResult Nouveaute()
        {
            if ((bool)Session["login"])
            {
                ViewBag.listeFilms = s.Read(Server.MapPath("~") + "films.txt");
                return View("Nouveaute");
            }
            else {
                return View("Login");
            }
        }

        // GET api/<controller>/5
        public Film Get(int id)
        {
            List<Film> list = s.Read(Server.MapPath("~") + "FilmSerializer.txt");
            return list.Find(x => x.Id == id); ;
        }

        // POST api/<controller>
        public void Post(string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}