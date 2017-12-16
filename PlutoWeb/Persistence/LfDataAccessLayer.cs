using System;
using System.Data.Entity;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence.EntityConfigurations;
using System.Configuration;

namespace PlutoWeb.Persistence
{
    public class LfDataAccessLayer
    {
      
      
        public string ConnectionStringGet()
        {
            return ConfigurationManager.ConnectionStrings["PlutoContext"].ConnectionString;

        }


    }
}
//public PlutoContext()
//            : base("name=PlutoContext")
//        {
//    this.Configuration.LazyLoadingEnabled = false;
//}