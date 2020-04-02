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
    public class UserSerializer
    {

        public static void Serialize(User input, string path)
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
                new XElement("password", input.Pass),
                new XElement("admin", input.Admin)
                );
            logins.Add(user);
            doc.Save(path);
        }

        public static List<User> Read(string path)
        {
            List<User> listUsers = new List<User>();
            try
            {
                foreach (XElement el in XElement.Load(path).Elements("User"))
                {
                    listUsers.Add(
                        new User(
                            el.Element("username").Value,
                            el.Element("password").Value,
                            bool.Parse(el.Element("admin").Value)
                            )
                        );
                }
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
            return listUsers;
        }
    }
}