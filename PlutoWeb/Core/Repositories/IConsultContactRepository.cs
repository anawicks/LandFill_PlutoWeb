using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;


namespace PlutoWeb.Core.Repositories
{
    public interface IConsultContactRepository : IRepository<tblConsultContacts>
    {
        IEnumerable<tblConsultContacts> GetConsultContact(int id);
        IEnumerable<tblConsultContacts> LkConsultContactIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
