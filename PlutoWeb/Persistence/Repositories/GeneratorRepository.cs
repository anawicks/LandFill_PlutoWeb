using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;


namespace PlutoWeb.Persistence.Repositories
{
    public class GeneratorRepository : Repository<tblGenerators>, IGeneratorRepository
    {
        public GeneratorRepository(PlutoContext context)
            : base(context)
        {
        }

        public IEnumerable<tblGenerators> GetGenerator(int id)
        {

            yield return PlutoContext.tblGenerators.FirstOrDefault(d => d.GeneratorId == id);

        }

        public IEnumerable<tblGenerators> LkGeneratorIndex(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.GeneratorPaging = new List<tblGenerators>();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblGenerators
                    .GroupBy(p => p.GeneratorName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {

                    model.GeneratorPaging
                       .AddRange((from item in context.tblGenerators.AsEnumerable()
                                  orderby item.GeneratorName
                                  select new tblGenerators()
                                  {
                                      GeneratorId = item.GeneratorId,
                                      GeneratorName = item.GeneratorName,
                                      GenaratorAddr = item.GenaratorAddr,
                                      GeneratorCity = item.GeneratorCity,
                                      GeneratorProv = item.GeneratorProv,
                                      GeneratorPostal = item.GeneratorPostal,
                                      GeneratorPhone = item.GeneratorPhone,
                                      GeneratorComments = item.GeneratorComments


                                  }).ToList());


                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.GeneratorPaging
                       .AddRange((from item in context.tblGenerators.AsEnumerable()
                                  .Where(item => numbers.Contains(item.GeneratorName.Substring(0, 1)))
                                  select new tblGenerators()
                                  {
                                      GeneratorId = item.GeneratorId,
                                      GeneratorName = item.GeneratorName,
                                      GenaratorAddr = item.GenaratorAddr,
                                      GeneratorCity = item.GeneratorCity,
                                      GeneratorProv = item.GeneratorProv,
                                      GeneratorPostal = item.GeneratorPostal,
                                      GeneratorPhone = item.GeneratorPhone,
                                      GeneratorComments = item.GeneratorComments


                                  }).ToList());
                    }
                    else
                    {
                        model.GeneratorPaging
                        .AddRange((from item in context.tblGenerators.AsEnumerable()
                                   .Where(item => item.GeneratorName.Trim().StartsWith(selectedLetter))
                                   select new tblGenerators()
                                   {
                                       GeneratorId = item.GeneratorId,
                                       GeneratorName = item.GeneratorName,
                                       GenaratorAddr = item.GenaratorAddr,
                                       GeneratorCity = item.GeneratorCity,
                                       GeneratorProv = item.GeneratorProv,
                                       GeneratorPostal = item.GeneratorPostal,
                                       GeneratorPhone = item.GeneratorPhone,
                                       GeneratorComments = item.GeneratorComments


                                   }).ToList());



                    }
                }
            }

            return model.GeneratorPaging;
        }




        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblGenerators
                    .GroupBy(p => p.GeneratorName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}
