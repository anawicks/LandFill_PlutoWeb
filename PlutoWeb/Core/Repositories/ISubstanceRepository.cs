using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories 
{
    public interface ISubstanceRepository : IRepository<tblSubstances>
    {
        IEnumerable<tblSubstances> GetSubstance(int id);
        IEnumerable<tblSubstances> LkSubstanceIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
