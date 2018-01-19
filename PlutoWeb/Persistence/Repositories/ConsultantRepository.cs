using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{
    public class ConsultantRepository : Repository<tblConsultants>, IConsultantRepository
    {

        public ConsultantRepository(PlutoContext context) 
            : base(context)
        {
        }

        public IEnumerable<tblConsultants> GetConsultant(int id)
        {
            yield return PlutoContext.tblConsultants.FirstOrDefault(d => d.ConsultantId == id);
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblConsultants
                    .GroupBy(p => p.ConsultantName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }


        public IEnumerable<tblConsultants> LkConsultantIndex(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.ConsultantPaging = new List<tblConsultants>();

            using (var context = new PlutoContext())
            {

                model.FirstLetters = context.tblConsultants
                    .GroupBy(p => p.ConsultantName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {

                   

                    model.ConsultantPaging
                        .AddRange((from item in context.tblConsultants.AsEnumerable()
                                   orderby item.ConsultantName
                                   select new tblConsultants()
                                   {
                                       ConsultantId = item.ConsultantId,
                                       ConsultantName = item.ConsultantName,
                                       ConsultantAddr = item.ConsultantAddr,
                                       ConsultantCity = item.ConsultantCity,
                                       ConsultantProv = item.ConsultantProv,
                                       ConsultantPostal = item.ConsultantPostal,
                                       ConsultantPhone = item.ConsultantPhone,
                                       ConsultantNotes = item.ConsultantNotes


                                   }).ToList());

                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.ConsultantPaging
                        .AddRange((from item in context.tblConsultants
                                   .Where(item => numbers.Contains(item.ConsultantName.Substring(0, 1)))
                                   select new tblConsultants()
                                   {
                                       ConsultantId = item.ConsultantId,
                                       ConsultantName = item.ConsultantName,
                                       ConsultantAddr = item.ConsultantAddr,
                                       ConsultantCity = item.ConsultantCity,
                                       ConsultantProv = item.ConsultantProv,
                                       ConsultantPostal = item.ConsultantPostal,
                                       ConsultantPhone = item.ConsultantPhone,
                                       ConsultantNotes = item.ConsultantNotes


                                   }).ToList());

                    }
                    else
                    {
                        model.ConsultantPaging
                        .AddRange((from item in context.tblConsultants.AsEnumerable()
                                   .Where(item => item.ConsultantName.Trim().StartsWith(selectedLetter))
                                   select new tblConsultants()
                                   {
                                       ConsultantId = item.ConsultantId,
                                       ConsultantName = item.ConsultantName,
                                       ConsultantAddr = item.ConsultantAddr,
                                       ConsultantCity = item.ConsultantCity,
                                       ConsultantProv = item.ConsultantProv,
                                       ConsultantPostal = item.ConsultantPostal,
                                       ConsultantPhone = item.ConsultantPhone,
                                       ConsultantNotes = item.ConsultantNotes


                                   }).ToList());



                    }
                }

            }



              return model.ConsultantPaging;


        }

     
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }

    internal class CategoryWrapper
    {
        public string ConsultantAddr { get; set; }
        public string ConsultantCity { get; set; }
        public int ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantNotes { get; set; }
        public string ConsultantPhone { get; set; }
        public string ConsultantPostal { get; set; }
        public string ConsultantProv { get; set; }
    }
}