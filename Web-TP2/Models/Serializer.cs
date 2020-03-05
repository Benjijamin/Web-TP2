using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Web_TP2.Models
{
    public class Serializer
    {

        public void Serialize(Login input, string path)
        {
            XDocument doc;
            if (!File.Exists(path))
            {
                doc = new XDocument(new XElement("Logins"));
            }
            else
            {
                doc = XDocument.Load(path);
            }
            XElement logins = doc.Element("Logins");
            XElement user = new XElement("User");
            
            user.Add(
                new XElement("username", input.Log),
                new XElement("password", input.Pass)
                );
            logins.Add(user);
            doc.Save(path);
        }

        public List<Object> Read(string path)
        {
            List<Object> listUsers = new List<Object>(); 

            XDocument doc = XDocument.Load(path);
            foreach (XElement el in XElement.Load(path).Elements("User")) {
                listUsers.Add(new Login(el.Element("username").Value,el.Element("password").Value));
            }

            return listUsers;
        }

    }
}