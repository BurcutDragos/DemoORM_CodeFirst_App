using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_MVC_ProjectDB.Models
{
    public class UploadedFileViewModel
    {
        public int FILE_ID { get; set; }
        // Foreign key to link with USER
        public int USER_ID { get; set; }
        public virtual USER USER { get; set; }
        public string FILE_NAME { get; set; }
        public string FILE_LOCATION { get; set; }
        public DateTime UPLOAD_DATE { get; set; }
    }
}