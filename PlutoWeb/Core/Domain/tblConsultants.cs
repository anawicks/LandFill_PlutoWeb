using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblConsultants
    {
        [Key]
        public int ConsultantId { get; set; }

        public string ConsultantName { get; set; }
        public string ConsultantAddr { get; set; }
        public string ConsultantCity { get; set; }
        public string ConsultantProv { get; set; }
        public string ConsultantPostal { get; set; }
        public string ConsultantPhone { get; set; }
        public string ConsultantNotes { get; set; } 


        







    }
}