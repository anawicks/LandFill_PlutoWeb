using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IGeneratorRepository : IRepository<tblGenerators>
    {
        IEnumerable<tblGenerators> GetGenerator(int id);
        IEnumerable<tblGenerators> LkGeneratorIndex(string selectedLetter);

        

        List<string> GetFirstLetter();
    }
}
