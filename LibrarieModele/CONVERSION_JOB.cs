using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarieModele
{
    public class CONVERSION_JOB
    {
        [Key]
        public int JOB_ID { get; set; }

        // Foreign key to link with UPLOADED_FILE
        public int FILE_ID { get; set; }

        public virtual UPLOADED_FILE UPLOADED_FILE { get; set; }

        public string CONVERSION_STATUS { get; set; }

        public DateTime? CONVERSION_START_TIME { get; set; }

        public DateTime? CONVERSION_END_TIME { get; set; }

        public string OUTPUT_FILE_LOCATION { get; set; }

        public string CONVERSION_MESSAGE { get; set; }

        public virtual ICollection<CONVERSION_HISTORY> CONVERSION_HISTORY { get; set; }
    }
}
