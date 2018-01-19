using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{
    public class TruckCompanyRepository : Repository<tblTruckCompanies>, ITruckCompanyRepository
    {

        public TruckCompanyRepository(PlutoContext context) 
            : base(context)
        {
        }

        public IEnumerable<tblTruckCompanies> GetTruckCompany(int id)
        {
            yield return PlutoContext.tblTruckCompanies.FirstOrDefault(d => d.TruckCompId == id);
                 
        }

        public List<string> GetFirstLetter()
       {
           var model = new AlphabeticalPagingViewModel();

           using (var context = new PlutoContext())
           {
               model.FirstLetters = context.tblTruckCompanies
                   .GroupBy(p => p.TruckCompName.Substring(0,1))
                   .Select(x => x.Key.ToUpper())
                   .ToList();
           }

           return model.FirstLetters;
       }
  
        public IEnumerable<tblTruckCompanies> LkTruckCompanyIndex(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.TruckCompanyPaging = new List<tblTruckCompanies>();

            using (var context = new PlutoContext())
            {

                model.FirstLetters = context.tblTruckCompanies
                    .GroupBy(p => p.TruckCompName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {

                    model.TruckCompanyPaging
                        .AddRange((from item in context.tblTruckCompanies.AsEnumerable()
                                   orderby item.TruckCompName
                                   select new tblTruckCompanies()
                                   {
                                       TruckCompId = item.TruckCompId,
                                       TruckCompName = item.TruckCompName,
                                       TruckCompAddr = item.TruckCompAddr,
                                       TruckCompCity = item.TruckCompCity,
                                       TruckCompProv = item.TruckCompProv,
                                       TruckCompPostal = item.TruckCompPostal,
                                       TruckCompPhone = item.TruckCompPhone


                                   }).ToList());

                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.TruckCompanyPaging
                        .AddRange((from item in context.tblTruckCompanies.AsEnumerable()
                                   .Where(item => numbers.Contains(item.TruckCompName.Substring(0, 1)))
                                   select new tblTruckCompanies()
                                   {
                                       TruckCompId = item.TruckCompId,
                                       TruckCompName = item.TruckCompName,
                                       TruckCompAddr = item.TruckCompAddr,
                                       TruckCompCity = item.TruckCompCity,
                                       TruckCompProv = item.TruckCompProv,
                                       TruckCompPostal = item.TruckCompPostal,
                                       TruckCompPhone = item.TruckCompPhone


                                   }).ToList());
                    }
                    else
                    {
                        model.TruckCompanyPaging
                        .AddRange((from item in context.tblTruckCompanies.AsEnumerable()
                                   .Where(item => item.TruckCompName.Trim().StartsWith(selectedLetter))
                                   select new tblTruckCompanies()
                                   {
                                       TruckCompId = item.TruckCompId,
                                       TruckCompName = item.TruckCompName,
                                       TruckCompAddr = item.TruckCompAddr,
                                       TruckCompCity = item.TruckCompCity,
                                       TruckCompProv = item.TruckCompProv,
                                       TruckCompPostal = item.TruckCompPostal,
                                       TruckCompPhone = item.TruckCompPhone


                                   }).ToList());



                    }
                }
            }
            return model.TruckCompanyPaging;
        }

        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}