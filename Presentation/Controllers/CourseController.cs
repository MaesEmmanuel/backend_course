using Business;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Course> Get()
        {
            return _courseService.GetAll();
        }

        [HttpGet("GetByName")]
        public Course GetByName(string name)
        {
            return _courseService.GetByName(name);
        }






    }
}
