﻿ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface ITruckCompanyRepository : IRepository<tblTruckCompanies>
    {
        IEnumerable<tblTruckCompanies> GetTruckCompany(int id);
        IEnumerable<tblTruckCompanies> LkTruckCompanyIndex(string selectedLetter);

        List<string> GetFirstLetter();
    }
}
