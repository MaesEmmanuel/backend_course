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

        public Course GetbyName(string name)
        {
         //  Course course   = _db.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
         //   return  _db.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
         return _db.FirstOrDefault(c => c.Name.ToLower() == name.ToLower()) as Course;
        }



            

    }


}