using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarieModele
{
    public class UPLOADED_FILE
    {
        [Key]
        public int FILE_ID { get; set; }

        // Foreign key to link with USER
        public int USER_ID { get; set; }

        public virtual USER USER { get; set; }

        public string FILE_NAME { get; set; }

        public string FILE_LOCATION { get; set; }

        public DateTime UPLOAD_DATE { get; set; }

        public virtual ICollection<CONVERSION_JOB> CONVERSION_JOB { get; set; }
    }
}
