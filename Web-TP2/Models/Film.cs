using System;
using System.Threading;

namespace Web_TP2.Models
{
    public class Film
    {
        private int id;
        private String nom;

        public static int globalId;



        public Film(String n)
        {
            this.Id = Interlocked.Increment(ref globalId);
            this.Nom = n;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }



    }
}