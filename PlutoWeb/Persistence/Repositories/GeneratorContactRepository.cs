using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{
    //IEnumerable<tblGeneratorContacts> GetGeneratorContact(int id);
    //IEnumerable<tblGeneratorContacts> LkGeneratorContactIndex(string selectedLetter);

    //List<string> GetFirstLetter();
    public class GeneratorContactRepository : Repository<tblGeneratorContacts>, IGeneratorContactRepository
    {

        public GeneratorContactRepository(PlutoContext context) 
            : base(context)
        {
        }

        public IEnumerable<tblGeneratorContacts> GetGeneratorContact(int id)
        {
            yield return PlutoContext.tblGeneratorContacts.FirstOrDefault(d => d.GenerContactId == id);
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblGeneratorContacts
                    .GroupBy(p => p.GenerContactName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }

        public IEnumerable<tblGeneratorContacts> LkGeneratorContactIndex(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.GeneratorContactPaging = new List<tblGeneratorContacts>();

            using (var context = new PlutoContext())
            {

                model.FirstLetters = context.tblGeneratorContacts
                    .GroupBy(p => p.GenerContactName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {
                    model.GeneratorContactPaging
                        .AddRange((from item in context.tblGeneratorContacts.AsEnumerable()
                                   orderby item.GenerContactName
                                   select new tblGeneratorContacts()
                                   {
                                       GenerContactId = item.GenerContactId,
                                       GenerContactGenerId = item.GenerContactGenerId,
                                       GenerContactName = item.GenerContactName,
                                       GenerContactPhone = item.GenerContactPhone,
                                       GenerContactCell = item.GenerContactCell,
                                       GenerContactFax = item.GenerContactFax


                                   }).ToList());


                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.GeneratorContactPaging
                        .AddRange((from item in context.tblGeneratorContacts.AsEnumerable()
                                   .Where(item => numbers.Contains(item.GenerContactName.Substring(0, 1)))
                                   select new tblGeneratorContacts()
                                   {
                                       GenerContactId = item.GenerContactId,
                                       GenerContactGenerId = item.GenerContactGenerId,
                                       GenerContactName = item.GenerContactName,
                                       GenerContactPhone = item.GenerContactPhone,
                                       GenerContactCell = item.GenerContactCell,
                                       GenerContactFax = item.GenerContactFax


                                   }).ToList());

                    }
                    else
                    {
                        model.GeneratorContactPaging
                        .AddRange((from item in context.tblGeneratorContacts.AsEnumerable()
                                   .Where(item => item.GenerContactName.Trim().StartsWith(selectedLetter))
                                   select new tblGeneratorContacts()
                                   {
                                       GenerContactId = item.GenerContactId,
                                       GenerContactGenerId = item.GenerContactGenerId,
                                       GenerContactName = item.GenerContactName,
                                       GenerContactPhone = item.GenerContactPhone,
                                       GenerContactCell = item.GenerContactCell,
                                       GenerContactFax = item.GenerContactFax


                                   }).ToList());


                    }






                }




            }

            return model.GeneratorContactPaging;
        }
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}