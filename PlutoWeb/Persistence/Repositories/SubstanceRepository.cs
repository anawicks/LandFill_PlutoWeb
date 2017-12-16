using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{
    public class SubstanceRepository : Repository<tblSubstances>, ISubstanceRepository
    {
    

        public SubstanceRepository(PlutoContext context) 
            : base(context)
        {
        }

        public IEnumerable<tblSubstances> GetSubstance(int id)
        {
            yield return PlutoContext.tblSubstances.FirstOrDefault(d => d.SubstanceId == id);
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblSubstances
                    .GroupBy(p => p.SubstanceName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }
        public IEnumerable<tblSubstances> LkSubstanceIndex(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.SubstancePaging = new List<tblSubstances>();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblSubstances
                    .GroupBy(p => p.SubstanceName.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {
                    model.SubstancePaging
                        .AddRange((from item in context.tblSubstances.AsEnumerable()
                                   orderby item.SubstanceName
                                   select new tblSubstances()
                                   {
                                       SubstanceId = item.SubstanceId,
                                       SubstanceName = item.SubstanceName,
                                       SubstanceCode = item.SubstanceCode


                                   }).ToList());
                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.SubstancePaging
                        .AddRange((from item in context.tblSubstances.AsEnumerable()
                                   .Where(item => numbers.Contains(item.SubstanceName.Substring(0, 1)))
                                   select new tblSubstances()
                                   {
                                       SubstanceId = item.SubstanceId,
                                       SubstanceName = item.SubstanceName,
                                       SubstanceCode = item.SubstanceCode


                                   }).ToList());

                    }
                    else
                    {
                        model.SubstancePaging
                        .AddRange((from item in context.tblSubstances.AsEnumerable()
                                   .Where(item => item.SubstanceName.Trim().StartsWith(selectedLetter))
                                   select new tblSubstances()
                                   {
                                       SubstanceId = item.SubstanceId,
                                       SubstanceName = item.SubstanceName,
                                       SubstanceCode = item.SubstanceCode


                                   }).ToList());



                    }

                }

            }
            return model.SubstancePaging;
        }
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}