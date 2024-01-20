using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarieModele
{
    public class CONVERSION_HISTORY
    {
        [Key]
        public int HISTORY_ID { get; set; }

        // Foreign key to link with CONVERSION_JOB
        public int JOB_ID { get; set; }

        public virtual CONVERSION_JOB CONVERSION_JOB { get; set; }

        public DateTime CONVERSION_START_TIME { get; set; }

        public DateTime CONVERSION_END_TIME { get; set; }

        public string INPUT_FILE_NAME { get; set; }

        public string OUTPUT_FILE_NAME { get; set; }

        // Foreign key to link with USER
        public int USER_ID { get; set; }

        public virtual USER USER { get; set; }
    }
}
