using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblSubstances
    {

        [Key]
        public int SubstanceId { get; set; }

        public string SubstanceName { get; set; }

        public string SubstanceCode { get; set; }


    }
}