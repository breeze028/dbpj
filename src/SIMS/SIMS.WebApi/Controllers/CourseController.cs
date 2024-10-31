using Microsoft.AspNetCore.Mvc;
using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Services.Course;

namespace SIMS.WebApi.Controllers
{
    /// <summary>
    /// 课程控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> logger;

        private readonly ICourseAppService courseAppService;

        public CourseController(ILogger<CourseController> logger, ICourseAppService courseAppService)
        {
            this.logger = logger;
            this.courseAppService = courseAppService;
        }

        [HttpGet]
        public PagedRequest<CourseEntity> GetCourses( int pageNum, int pageSize, string? courseName=null, string? teacher=null) { 
            return courseAppService.GetCourses(courseName,teacher,pageNum,pageSize);
        }

        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public CourseEntity GetCourse(int id)
        {
            return courseAppService.GetCourse(id);
        }

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddCourse(CourseEntity course)
        {
            return courseAppService.AddCourse(course);
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateCourse(CourseEntity course)
        {
            return courseAppService.UpdateCourse(course);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public int DeleteCourse(int id)
        {
            return courseAppService.DeleteCourse(id);
        }
    }
}
