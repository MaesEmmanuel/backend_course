using Domain;
using System.ComponentModel;
using System.Xml.Linq;

namespace Business
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
      
        Course GetByName(string name);

    //    Course GetById(int id);
    //    Course AddCourse(Course course);
    }
}