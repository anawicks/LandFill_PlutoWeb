using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{
    //IEnumerable<tblInvoicees> GetInvoicee(int id);
    //IEnumerable<tblInvoicees> LkInvoiceeIndex(string selectedLetter);

    //List<string> GetFirstLetter();
    public class InvoiceeRepository : Repository<tblInvoicees>, IInvoiceeRepository
    {

        public InvoiceeRepository(PlutoContext context) 
            : base(context)
        {
        }

        public IEnumerable<tblInvoicees> GetInvoicee(int id)
        {
            yield return PlutoContext.tblInvoicees.FirstOrDefault(d => d.InvoiceeID == id);

                 
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblInvoicees
                    .GroupBy(p => p.InvoiceeName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }

        public IEnumerable<tblInvoicees> LkInvoiceeIndex(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.InvoiceePaging = new List<tblInvoicees>();

            using (var context = new PlutoContext())
            {

                model.FirstLetters = context.tblInvoicees
                    .GroupBy(p => p.InvoiceeName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {

                    model.InvoiceePaging
                        .AddRange((from item in context.tblInvoicees.AsEnumerable()
                       orderby item.InvoiceeName
                       select new tblInvoicees()
                       {
                           InvoiceeID = item.InvoiceeID,
                           InvoiceeName = item.InvoiceeName,
                           InvoiceeAddr = item.InvoiceeAddr,
                           InvoiceeCity = item.InvoiceeCity,
                           InvoiceeProv = item.InvoiceeProv,
                           InvoiceePostal = item.InvoiceePostal,
                           InvoiceePhone = item.InvoiceePhone,
                           InvoiceeConsultId = item.InvoiceeConsultId,
                           InvoiceeAttnTo = item.InvoiceeAttnTo,
                           InvoiceeCareOf = item.InvoiceeCareOf


                       }).ToList());



                }
                else
                {
                    if (selectedLetter == "0-9")
                    {

                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.InvoiceePaging
                        .AddRange((from item in context.tblInvoicees.AsEnumerable()
                                   .Where(item => numbers.Contains(item.InvoiceeName.Substring(0, 1)))
                                   select new tblInvoicees()
                                   {
                                       InvoiceeID = item.InvoiceeID,
                                       InvoiceeName = item.InvoiceeName,
                                       InvoiceeAddr = item.InvoiceeAddr,
                                       InvoiceeCity = item.InvoiceeCity,
                                       InvoiceeProv = item.InvoiceeProv,
                                       InvoiceePostal = item.InvoiceePostal,
                                       InvoiceePhone = item.InvoiceePhone,
                                       InvoiceeConsultId = item.InvoiceeConsultId,
                                       InvoiceeAttnTo = item.InvoiceeAttnTo,
                                       InvoiceeCareOf = item.InvoiceeCareOf


                                   }).ToList());


                    }
                    else
                    {

                        model.InvoiceePaging
                        .AddRange((from item in context.tblInvoicees.AsEnumerable()
                                   .Where(item => item.InvoiceeName.Trim().StartsWith(selectedLetter))
                                   select new tblInvoicees()
                                   {
                                       InvoiceeID = item.InvoiceeID,
                                       InvoiceeName = item.InvoiceeName,
                                       InvoiceeAddr = item.InvoiceeAddr,
                                       InvoiceeCity = item.InvoiceeCity,
                                       InvoiceeProv = item.InvoiceeProv,
                                       InvoiceePostal = item.InvoiceePostal,
                                       InvoiceePhone = item.InvoiceePhone,
                                       InvoiceeConsultId = item.InvoiceeConsultId,
                                       InvoiceeAttnTo = item.InvoiceeAttnTo,
                                       InvoiceeCareOf = item.InvoiceeCareOf


                                   }).ToList());

                    }


                }



            }
            return model.InvoiceePaging;

        }

        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}