using System;
using System.Threading;

namespace Web_TP2.Models
{
    public class Film
    {
        private int id;
        private string nom;
        private string image;
        private string lien;

        public static int globalId;



        public Film(string n)
        {
            Id = Interlocked.Increment(ref globalId);
            Nom = n;
            Image = "noimage.jpg";
            Lien = "https://www.youtube.com/watch?v=oHg5SJYRHA0";
        }


        public Film(int id, string n, string image, string lien) {
            Id = id;
            Nom = n;
            Image = image;
            Lien = lien;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Image { get => image; set => image = value; }
        public string Lien { get => lien; set => lien = value; }
    }
}