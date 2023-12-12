using Domain;

namespace DataAccess
{
    public class CourseRepository: ICourseRepository
    {
        private static List<Course> _db = new List<Course> {
            new Course("Web", "Web is fun", "Developer"),
            new Course("Security", "Security is important", "Admin"),
            new Course("Network", "Network connects the world", "Admin"),
            new Course("Database", "Database contains our data", "DBA"),
        };
        public IEnumerable<Course> GetAll() {

            return _db;
        }

    }

    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
    }
}