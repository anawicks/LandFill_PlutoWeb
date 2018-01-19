using PlutoWeb.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoWeb.Models
{
    public class AlphabeticalPagingViewModel
    {
        public List<tblConsultants> ConsultantPaging { get; set; }
        public List<tblGenerators> GeneratorPaging { get; set; }

        public List<tblTruckCompanies> TruckCompanyPaging { get; set; }

        public List<tblSubstances> SubstancePaging { get; set; }

        public List<tblInvoicees> InvoiceePaging { get; set; }

        public List<tblInterestCharges> InterestChargePaging { get; set; }

        public List<tblGeneratorLocations> GeneratorLocationPaging { get; set; }

        public List<tblGeneratorContacts> GeneratorContactPaging { get; set; }

        public List<tblConsultContacts> ConsultContactPaging { get; set; }

        public List<tblWasteDescriptionCode> WasteDescCodesPaging { get; set; }

        public List<string> FirstLetters { get; set; }
        public string SelectedLetter { get; set; }
    }
}