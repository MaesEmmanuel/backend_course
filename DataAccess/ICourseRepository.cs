using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetbyName(string name);
    }
}
