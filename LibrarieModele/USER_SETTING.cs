using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarieModele
{
    public class USER_SETTING
    {
        [Key]
        public int SETTING_ID { get; set; }

        // Foreign key to link with USER
        public int USER_ID { get; set; }

        public virtual USER USER { get; set; }

        public string SETTING_NAME { get; set; }

        public string SETTING_VALUE { get; set; }
    }
}
