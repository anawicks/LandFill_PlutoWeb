using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IConsultantRepository : IRepository<tblConsultants>
    {
        IEnumerable<tblConsultants> GetConsultant(int id);
        IEnumerable<tblConsultants> LkConsultantIndex(string selectedLetter);

        List<string> GetFirstLetter();
        //object LkConsultantIndex(char v);

        //public IEnumerable<tblConsultants> LkConsultantIndex(string selectedLetter)
    }
}
