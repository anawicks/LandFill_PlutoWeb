using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;

namespace PlutoWeb.Persistence.Repositories
{ 
    public class GeneratorLocationRepository : Repository<tblGeneratorLocations>, IGeneratorLocationRepository
    {
        public GeneratorLocationRepository(PlutoContext context) 
            : base(context)
        {
        }
        public IEnumerable<tblGeneratorLocations> GetGeneratorLocation(int id)
        {
            yield return PlutoContext.tblGeneratorLocations.FirstOrDefault(d => d.GenerLocationId == id);
        }
        public List<string> GetFirstLetter()
        {
            var model = new AlphabeticalPagingViewModel();

            using (var context = new PlutoContext())
            {
                model.FirstLetters = context.tblGeneratorLocations
                    .GroupBy(p => p.GenerLocationLsd.Substring(0, 1))
                    .Select(x => x.Key.ToUpper())
                    .ToList();
            }

            return model.FirstLetters;
        }


        public IEnumerable<tblGeneratorLocations> LkGeneratorLocationIndex(string selectedLetter)
        {


            var model = new AlphabeticalPagingViewModel();

            model.SelectedLetter = selectedLetter;

            model.GeneratorLocationPaging = new List<tblGeneratorLocations>();

            using (var context = new PlutoContext())
            {

                model.FirstLetters = context.tblGeneratorLocations
                   .GroupBy(p => p.GenerLocationLsd.Substring(0, 1))
                   .Select(x => x.Key.ToUpper())
                   .ToList();

                if (string.IsNullOrEmpty(selectedLetter) || selectedLetter.ToUpper() == "ALL")
                {
                    model.GeneratorLocationPaging
                        .AddRange((from item in context.tblGeneratorLocations.AsEnumerable()
                                   orderby item.GenerLocationLsd
                                   select new tblGeneratorLocations()
                                   {
                                       GenerLocationId = item.GenerLocationId,
                                       GenerLocationGenID = item.GenerLocationGenID,
                                       GenerLocationLsd = item.GenerLocationLsd


                                   }).ToList());
                }
                else
                {
                    if (selectedLetter == "0-9")
                    {
                        var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());

                        model.GeneratorLocationPaging
                        .AddRange((from item in context.tblGeneratorLocations.AsEnumerable()
                                   .Where(item => numbers.Contains(item.GenerLocationLsd.Substring(0, 1)))
                                   select new tblGeneratorLocations()
                                   {
                                       GenerLocationId = item.GenerLocationId,
                                       GenerLocationGenID = item.GenerLocationGenID,
                                       GenerLocationLsd = item.GenerLocationLsd


                                   }).ToList());




                    }
                    else
                    {

                        model.GeneratorLocationPaging
                        .AddRange((from item in context.tblGeneratorLocations.AsEnumerable()
                                   .Where(item => item.GenerLocationLsd.Trim().StartsWith(selectedLetter))
                                   select new tblGeneratorLocations()
                                   {
                                       GenerLocationId = item.GenerLocationId,
                                       GenerLocationGenID = item.GenerLocationGenID,
                                       GenerLocationLsd = item.GenerLocationLsd


                                   }).ToList());



                    }




                }


            }


            return model.GeneratorLocationPaging;

        }
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}