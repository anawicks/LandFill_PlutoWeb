using System.Data.Entity;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence.EntityConfigurations;

namespace PlutoWeb.Persistence
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<tblConsultants> tblConsultants { get; set; }
        public virtual DbSet<tblGenerators> tblGenerators { get; set; }

        public virtual DbSet<tblTruckCompanies> tblTruckCompanies { get; set; }

        public virtual DbSet<tblSubstances> tblSubstances { get; set; }         

        public virtual DbSet<tblInvoicees> tblInvoicees { get; set; }       

        public virtual DbSet<tblInterestCharges> tblInterestCharges { get; set; }
       
        public virtual DbSet<tblGeneratorLocations> tblGeneratorLocations { get; set; }

        public virtual DbSet<tblGeneratorContacts> tblGeneratorContacts { get; set; }

        public virtual DbSet<tblConsultContacts> tblConsultContacts { get; set; }
        
        public virtual DbSet<tblWasteDescriptionCode> tblWasteDescriptionCode { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());

           
        }

        public System.Data.Entity.DbSet<PlutoWeb.Core.Domain.tblLandFillDocket> tblLandFillDockets { get; set; }
    }
}
