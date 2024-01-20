using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersApp.Models
{
    public class User
    {
        [Key]
        public int USER_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public DateTime REGISTRATION_DATE { get; set; }
        public DateTime LAST_LOGIN_DATE { get; set; }
    }
}