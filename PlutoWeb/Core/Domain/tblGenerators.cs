using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace PlutoWeb.Core.Domain
{
    public class tblGenerators
    {
        [Key]
        public int GeneratorId { get; set; }

        public string GeneratorName { get; set; }
        public string GenaratorAddr { get; set; }
        public string GeneratorCity { get; set; }
        public string GeneratorProv { get; set; }
        public string GeneratorPostal { get; set; }
        public string GeneratorPhone { get; set; }
        public string GeneratorComments { get; set; }

        public bool GeneratorExcldInterest { get; set; }
    }

    
    







}