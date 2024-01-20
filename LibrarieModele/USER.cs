using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarieModele
{
    public class USER
    {
        [Key]
        public int USER_ID { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; } // Store the hashed and salted password

        public string EMAIL { get; set; }

        public string PHONE { get; set; }

        public DateTime REGISTRATION_DATE { get; set; }

        public DateTime LAST_LOGIN_DATE { get; set; }

        // Navigation property for the one-to-many relationship with UPLOADED_FILE
        public virtual ICollection<UPLOADED_FILE> UPLOADED_FILE { get; set; }

        // Navigation property for the one-to-one relationship with USER_SETTING (if applicable)
        public virtual ICollection<USER_SETTING> USER_SETTING { get; set; }
    }
}
