using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web_TP2.Models;

namespace Web_TP2.Controllers
{
    public class FilmController : Controller
    {
        public ActionResult Nouveaute()
        {
            if ((bool)Session["login"])
            {
                ViewBag.listeFilms = FilmSerializer.Read(Server.MapPath("~") + "films.txt");
                return View("Nouveaute");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Get(int id)
        {
            if ((bool)Session["login"])
            {
                List<Film> list = FilmSerializer.Read(Server.MapPath("~") + "films.txt");
                ViewBag.film = list.Find(x => x.Id == id);
                return View("Film");
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult MaListe()
        {
            if ((bool)Session["login"])
            {
                List<Film> maListe = FilmSerializer.ReadUserList((string)Session["user"], Server.MapPath("~") + "playlists.txt");
                ViewBag.maListe = maListe;
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult AjoutMaListe()
        {
            int id = Int32.Parse(Request.Form["FilmId"]);

            List<Film> listeFilms = FilmSerializer.Read(Server.MapPath("~") + "films.txt");
            Film film = listeFilms.Find(x => x.Id == id);
            FilmSerializer.AddToUserList(film, (string)Session["user"], Server.MapPath("~") + "playlists.txt");

            return Redirect(Request.UrlReferrer.ToString());
        }

        public void Post(string value)
        {
        }

        public void Put(int id, string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}