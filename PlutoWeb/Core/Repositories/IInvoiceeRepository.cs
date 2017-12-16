using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface IInvoiceeRepository : IRepository<tblInvoicees>
    {
        IEnumerable<tblInvoicees> GetInvoicee(int id);
        IEnumerable<tblInvoicees> LkInvoiceeIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
