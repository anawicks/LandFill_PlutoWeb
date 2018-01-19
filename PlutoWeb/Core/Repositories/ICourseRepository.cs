using System.Collections.Generic;
using PlutoWeb.Core.Domain;

namespace PlutoWeb.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        //IEnumerable<Course> GetTopConsultant(int id);
       IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}