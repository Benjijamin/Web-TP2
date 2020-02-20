using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web_TP2.Models
{
    public class Serializer<T>
    {

        public void Serialize(T input, string path)
        {
            XmlSerializer writer = new XmlSerializer(typeof(T));
            bool existe = File.Exists(path);
            if (!existe) {
                Stream s = File.Create(path);
                writer.Serialize(s, input);
            }else
            {
                StreamWriter s = File.AppendText(path);
                writer.Serialize(s, input);
            }
            s.Close();
        }

        public List<T> Read(string path)
        {

            return new List<T>();
        }

    }
}