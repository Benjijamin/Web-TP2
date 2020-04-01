using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Web_TP2.Models
{
    public class FilmSerializer
    {
        public void Serialize(Film input, string path)
        {
            XDocument doc;
            if (!File.Exists(path))
            {
                doc = new XDocument(new XElement("Films"));
            }
            else
            {
                doc = XDocument.Load(path);
            }
            XElement films = doc.Element("Films");
            XElement film = new XElement("Film");

            film.Add(
                new XElement("id", input.Id),
                new XElement("nom", input.Nom)
                );
            films.Add(film);
            doc.Save(path);
        }

        public List<Film> Read(string path)
        {
            List<Film> listFilms = new List<Film>();
            try
            {
                XDocument doc = XDocument.Load(path);
                foreach (XElement el in XElement.Load(path).Elements("User"))
                {
                    listFilms.Add(new Film(Int32.Parse(el.Element("id").Value), el.Element("nom").Value));
                }
            }
            catch (FileNotFoundException e) {
                return null;
            }
            return listFilms;
        }
    }
}