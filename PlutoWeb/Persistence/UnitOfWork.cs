using PlutoWeb.Core;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Persistence.Repositories;

namespace PlutoWeb.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;
        private readonly LfDataAccessLayer _cncontext;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
            Consultants = new ConsultantRepository(_context);
            Generators = new GeneratorRepository(_context);
            TruckCompanies = new TruckCompanyRepository(_context);
            Substances = new SubstanceRepository(_context);
            WasteDescCodes = new WasteDescCodesRepository(_context);
            GeneratorLocations = new GeneratorLocationRepository(_context);
            GeneratorContacts = new GeneratorContactRepository(_context);
            ConsultContacts = new ConsultContactRepository(_context);
        }
        //public UnitOfWork(LfDataAccessLayer cncontext)
        //{
        //    _cncontext = cncontext;
        //    WasteDockets = new LfDocketRepository(_cncontext);

        //}
        // public List<tblConsultContacts> ConsultContactPaging { get; set; }
        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public IConsultantRepository Consultants { get; private set; }

        public IGeneratorRepository Generators { get; private set; }
 
        public ITruckCompanyRepository TruckCompanies { get; private set; }
        public ISubstanceRepository Substances { get; private set; }
        public IInvoiceeRepository Invoicees { get; private set; }
        public IInterestChargeRepository InterestCharges { get; private set; }
        public IGeneratorLocationRepository GeneratorLocations { get; private set; }
        public IGeneratorContactRepository GeneratorContacts { get; private set; }
        public IConsultContactRepository ConsultContacts { get; private set; }

        public IWasteDescCodesRepository WasteDescCodes { get; private set; }

       
        public ILfDocketRepository WasteDockets
        {

            get; private set;
     

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
   
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}