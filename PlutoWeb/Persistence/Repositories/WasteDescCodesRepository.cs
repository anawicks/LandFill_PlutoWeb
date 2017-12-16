using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{
    public class WasteDescCodesRepository : Repository<tblWasteDescriptionCode>, IWasteDescCodesRepository
    {
        public WasteDescCodesRepository(PlutoContext context) 
            : base(context)
        {
        }
        public IEnumerable<tblWasteDescriptionCode> GetWasteDescCode(int id)
        {
            yield return PlutoContext.tblWasteDescriptionCode.FirstOrDefault(k => k.WasteDescriptionId == id);
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblWasteDescriptionCode
                    .GroupBy(p => p.WasteDescription.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }

        public IEnumerable<tblWasteDescriptionCode> LkWasteDescCodeIndex(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.WasteDescCodesPaging = new List<tblWasteDescriptionCode>();

            using (var context = new PlutoContext())
            {
                //model.FirstLetters = context.tblWasteDescriptionCode
                //    .GroupBy(p => p.WasteDescription.Substring(0, 1))
                //    .Select(x => x.Key.ToUpper())
                //    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {
                    model.WasteDescCodesPaging
                        .AddRange((from item in context.tblWasteDescriptionCode.AsEnumerable()
                                   orderby item.WasteDescription
                                   select new tblWasteDescriptionCode()
                                   {
                                       WasteDescriptionId = item.WasteDescriptionId,
                                       WasteDescription = item.WasteDescription,
                                       WasteDescriptionCode = item.WasteDescriptionCode,
                                       WasteDescriptionInvoice = item.WasteDescriptionInvoice 


                                   }).ToList());


                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.WasteDescCodesPaging
                        .AddRange((from item in context.tblWasteDescriptionCode.AsEnumerable()
                                   .Where(item => numbers.Contains(item.WasteDescription.Substring(0, 1)))
                                   select new tblWasteDescriptionCode()
                                   {
                                       WasteDescriptionId = item.WasteDescriptionId,
                                       WasteDescription = item.WasteDescription,
                                       WasteDescriptionCode = item.WasteDescriptionCode,
                                       WasteDescriptionInvoice = item.WasteDescriptionInvoice


                                   }).ToList());


                    }
                    else
                    {
                        model.WasteDescCodesPaging
                       .AddRange((from item in context.tblWasteDescriptionCode.AsEnumerable()
                                  .Where(item => item.WasteDescription.Trim().StartsWith(selectedLetter))
                                  select new tblWasteDescriptionCode()
                                  {
                                      WasteDescriptionId = item.WasteDescriptionId,
                                      WasteDescription = item.WasteDescription,
                                      WasteDescriptionCode = item.WasteDescriptionCode,
                                      WasteDescriptionInvoice = item.WasteDescriptionInvoice


                                  }).ToList());


                    }


                }




            }


            return model.WasteDescCodesPaging;


        }
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}
//IEnumerable<tblWasteDescriptionCode> GetWasteDescCode(int id);
//IEnumerable<tblWasteDescriptionCode> LkWasteDescCodeIndex(string selectedLetter);

//List<string> GetFirstLetter();