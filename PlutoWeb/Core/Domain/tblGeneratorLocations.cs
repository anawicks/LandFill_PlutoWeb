using System;
 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlutoWeb.Core.Domain
{
    public class tblGeneratorLocations
    {
        [Key]
        public int GenerLocationId { get; set; }

        public int GenerLocationGenID { get; set; }

        public string GenerLocationLsd { get; set; }
    }
}