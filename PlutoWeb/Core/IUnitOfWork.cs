using System;
using PlutoWeb.Core.Repositories;

namespace PlutoWeb.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }

        IConsultantRepository Consultants { get; }

        IGeneratorRepository Generators { get; }
        ITruckCompanyRepository TruckCompanies { get; }
        ISubstanceRepository Substances { get; }
        IInvoiceeRepository Invoicees { get; }
        IInterestChargeRepository InterestCharges { get; }
        IGeneratorLocationRepository GeneratorLocations { get; }
        IGeneratorContactRepository GeneratorContacts { get; }
        IConsultContactRepository ConsultContacts { get; }

        IWasteDescCodesRepository WasteDescCodes { get; }
        ILfDocketRepository WasteDockets { get; }


        int Complete();
    }
}