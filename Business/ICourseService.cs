using Domain;

namespace Business
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
    }
}