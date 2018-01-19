using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblGeneratorContacts
    {
        [Key]
        public int GenerContactId { get; set; }

        public int GenerContactGenerId { get; set; }
        public string GenerContactName { get; set; }
        public string GenerContactPhone { get; set; }
        public string GenerContactCell { get; set; }
        public string GenerContactFax { get; set; }
    }
}