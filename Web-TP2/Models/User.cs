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

        public User() {
            Log = null;
            Pass = null;
        }

        public User(string login, string pass)
        {
            Log = login;
            Pass = pass;
        }

        public string Log { get => log; set => log = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}