using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface ILfDocketRepository 
        //: IRepository<tblLandFillDocket>
    
    {
        
        IEnumerable<tblLandFillDocket> GetDocket(int id);

       
        
    }
}
