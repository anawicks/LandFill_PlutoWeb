using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblInterestCharges
    {
        [Key]
        public int IntAmount { get; set; }

        public int IntDaysOverdue { get; set; }
    }
}