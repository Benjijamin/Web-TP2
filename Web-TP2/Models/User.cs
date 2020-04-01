using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TP2.Models
{
    public class User
    {

        private string log;
        private string pass;
        private bool admin;

        public User() {
            Log = null;
            Pass = null;
            Admin = false;
        }

        public User(string login, string pass)
        {
            Log = login;
            Pass = pass;
            Admin = false;
        }

        public User(string login, string pass, bool admin)
        {
            Log = login;
            Pass = pass;
            Admin = admin;
        }

        public string Log { get => log; set => log = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
}