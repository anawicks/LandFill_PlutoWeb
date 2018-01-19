using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblWasteDescriptionCode
    {
        [Key]
        public int WasteDescriptionId { get; set; }

        public string WasteDescription { get; set; }
        public string WasteDescriptionCode { get; set; }
        public string WasteDescriptionInvoice { get; set; }
    }
}