using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_MVC_ProjectDB.Models
{
    public class UserViewModel
    {
        public int USER_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; } // Store the hashed and salted password
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public DateTime REGISTRATION_DATE { get; set; }
        public DateTime LAST_LOGIN_DATE { get; set; }
    }
}