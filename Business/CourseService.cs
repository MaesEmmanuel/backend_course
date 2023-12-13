using DataAccess;
using Domain;

namespace Business
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<Course> GetAll() {
         //   var course= _courseRepository.GetAll();
         //   course.ToList().ForEach(course => course.Name = course.Name.ToUpper());
            return _courseRepository.GetAll(); 
        }

        public Course GetByName(string name)
        {

            return _courseRepository.GetbyName(name);
        }
     

    }
}