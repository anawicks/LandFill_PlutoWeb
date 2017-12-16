using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblInvoicees
    {
        [Key]
        public int InvoiceeID { get; set; }

        public string InvoiceeName { get; set; }

        public string InvoiceeAddr { get; set; }
        public string InvoiceeCity { get; set; }
        public string InvoiceeProv { get; set; }
        public string InvoiceePostal { get; set; }
        public string InvoiceePhone { get; set; }
        public int InvoiceeConsultId { get; set; }
        public string InvoiceeAttnTo { get; set; }

        public string InvoiceeCareOf { get; set; }
    }
}