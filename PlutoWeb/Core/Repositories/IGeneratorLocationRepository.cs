using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IGeneratorLocationRepository : IRepository<tblGeneratorLocations>
    {
        IEnumerable<tblGeneratorLocations> GetGeneratorLocation(int id);
        IEnumerable<tblGeneratorLocations> LkGeneratorLocationIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
