using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarieModele
{
    public class USER_ACTIVITY_LOG
    {
        [Key]
        public int LOG_ID { get; set; }

        // Foreign key to link with USER
        public int USER_ID { get; set; }
        public virtual USER USER { get; set; }

        public string ACTIVITY_TYPE { get; set; }

        public DateTime ACTIVITY_DATE { get; set; }

        public string DETAILS { get; set; }
    }
}
