using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;


namespace PlutoWeb.Persistence.Repositories
{
    //IEnumerable<tblConsultContacts> GetConsultContact(int id);
    //IEnumerable<tblConsultContacts> LkConsultContactIndex(string selectedLetter);

    //List<string> GetFirstLetter();
    public class ConsultContactRepository : Repository<tblConsultContacts>, IConsultContactRepository
    {

        public ConsultContactRepository(PlutoContext context) 
            : base(context)
        {
        }

        public IEnumerable<tblConsultContacts> GetConsultContact(int id)
        {
            yield return PlutoContext.tblConsultContacts.FirstOrDefault(d => d.ConsultantContactId == id);
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblConsultContacts
                    .GroupBy(p => p.ConsultantContactName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }

        public IEnumerable<tblConsultContacts> LkConsultContactIndex(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.ConsultContactPaging = new List<tblConsultContacts>();

            using (var context = new PlutoContext())
            {

                model.FirstLetters = context.tblConsultContacts
                    .GroupBy(p => p.ConsultantContactName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {
                    model.ConsultContactPaging
                        .AddRange((from item in context.tblConsultContacts.AsEnumerable()
                                   orderby item.ConsultantContactName
                                   select new tblConsultContacts()
                                   {
                                       ConsultantContactId = item.ConsultantContactId,
                                       ConsultantContactConsultId = item.ConsultantContactConsultId,
                                       ConsultantContactName = item.ConsultantContactName,
                                       ConsultantContactPhone = item.ConsultantContactPhone


                                   }).ToList());



                }
                else
                {

                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.ConsultContactPaging
                        .AddRange((from item in context.tblConsultContacts.AsEnumerable()
                                   .Where(item => numbers.Contains(item.ConsultantContactName.Substring(0, 1)))
                                   select new tblConsultContacts()
                                   {
                                       ConsultantContactId = item.ConsultantContactId,
                                       ConsultantContactConsultId = item.ConsultantContactConsultId,
                                       ConsultantContactName = item.ConsultantContactName,
                                       ConsultantContactPhone = item.ConsultantContactPhone


                                   }).ToList());

                    }
                    else
                    {
                        model.ConsultContactPaging
                        .AddRange((from item in context.tblConsultContacts.AsEnumerable()
                                   .Where(item => item.ConsultantContactName.Trim().StartsWith(selectedLetter))
                                   select new tblConsultContacts()
                                   {
                                       ConsultantContactId = item.ConsultantContactId,
                                       ConsultantContactConsultId = item.ConsultantContactConsultId,
                                       ConsultantContactName = item.ConsultantContactName,
                                       ConsultantContactPhone = item.ConsultantContactPhone


                                   }).ToList());




                    }





                }



            }



                return model.ConsultContactPaging;

        }




        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}