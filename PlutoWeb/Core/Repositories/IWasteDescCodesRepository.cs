using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IWasteDescCodesRepository : IRepository<tblWasteDescriptionCode>
    {

        IEnumerable<tblWasteDescriptionCode> GetWasteDescCode(int id);
        IEnumerable<tblWasteDescriptionCode> LkWasteDescCodeIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
