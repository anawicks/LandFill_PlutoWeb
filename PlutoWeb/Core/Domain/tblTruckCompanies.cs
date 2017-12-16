using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblTruckCompanies
    {

        [Key]
        public int TruckCompId { get; set; }

        public string TruckCompName { get; set; }
        public string TruckCompAddr { get; set; }
        public string TruckCompCity { get; set; }
        public string TruckCompProv { get; set; }
        public string TruckCompPostal { get; set; }
        public string TruckCompPhone { get; set; }

    }
}