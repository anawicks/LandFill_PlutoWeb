using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IGeneratorContactRepository : IRepository<tblGeneratorContacts>
    {
        IEnumerable<tblGeneratorContacts> GetGeneratorContact(int id);
        IEnumerable<tblGeneratorContacts> LkGeneratorContactIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
