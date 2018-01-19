using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IInterestChargeRepository : IRepository<tblInterestCharges>
    {

        IEnumerable<tblInterestCharges> GetInterestCharge(int id);
        IEnumerable<tblInterestCharges> LkInterestChargeIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
