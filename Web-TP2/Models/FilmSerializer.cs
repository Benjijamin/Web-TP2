﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Web_TP2.Models
{
    public class FilmSerializer
    {
        public static void Serialize(Film input, string path)
        {
            XDocument doc = !File.Exists(path) ? new XDocument(new XElement("Films")) : XDocument.Load(path);

            XElement films = doc.Element("Films");
            XElement film = new XElement("Film");

            film.Add(
                new XElement("id", input.Id),
                new XElement("nom", input.Nom),
                new XElement("image", input.Image)
                );
            films.Add(film);
            doc.Save(path);
        }

        public static void AddToUserList(Film input, string username, string path)
        {
            XDocument doc = !File.Exists(path) ? new XDocument(new XElement("Playlists")) : XDocument.Load(path);

            XElement listeUsers = doc.Element("Playlists");
            XElement film = new XElement("Film");

            film.Add(
                new XElement("id", input.Id),
                new XElement("nom", input.Nom),
                new XElement("image", input.Image)
                );

            if (listeUsers.Elements(username).Any())
            {
                listeUsers.Element(username).Element("Films").Add(film);
            }
            else
            {
                XElement user = new XElement(username);
                XElement films = new XElement("Films");
                films.Add(film);
                user.Add(films);
                listeUsers.Add(user);
            }
            doc.Save(path);
        }

        public static List<Film> Read(string path)
        {
            List<Film> listFilms = new List<Film>();
            XDocument doc = XDocument.Load(path);
            foreach (XElement el in XElement.Load(path).Elements("Film"))
            {
                listFilms.Add(new Film(Int32.Parse(el.Element("id").Value), el.Element("nom").Value, el.Element("image").Value));
            }
            return listFilms;
        }

        public static List<Film> ReadUserList(string username, string path)
        {
            //Faire ca
            return null;
        }
    }
}