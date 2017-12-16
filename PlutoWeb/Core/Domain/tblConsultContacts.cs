using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblConsultContacts
    {
        [Key]
        public int ConsultantContactId { get; set; }

        public int ConsultantContactConsultId { get; set; }
        public string ConsultantContactName { get; set; }
        public string ConsultantContactPhone { get; set; }
    }
}