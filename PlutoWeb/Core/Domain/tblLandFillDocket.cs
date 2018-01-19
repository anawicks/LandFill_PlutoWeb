using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    //[Table("tblLandFillWasteDocket")]
    public class tblLandFillDocket
    {
        //Projecy Information
       
        [Key]
        public int DocketId { get; set; }
        public string DocketNo { get; set; }
        public string WasteApprovalCode { get; set; }

        public int InvoiceeId { get; set; }

        public int TurckCompanyId { get; set; }

        public string DriverName { get; set; }

        public string DestinatedFor { get; set; }
        public string ScaleTicket { get; set; }

        public decimal ScaleGross { get; set; }
        public decimal ScaleTare { get; set; }

        public decimal ScaleNet { get; set; }

        public string Cell { get; set; }
        public string GridLetter { get; set; }
        public string GridNo { get; set; }

        public string Elevation { get; set; }
        public DateTime DateReceived { get; set; }

        public string MemoText { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime LoadReceiveDate { get; set; }



      





    }

}