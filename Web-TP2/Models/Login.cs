using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TP2.Models
{
    public class Login
    {

        private string log;
        private string pass;

        public Login(string login, string pass)
        {
            Log = login;
            Pass = pass;
        }

        public string Log { get => log; set => log = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}