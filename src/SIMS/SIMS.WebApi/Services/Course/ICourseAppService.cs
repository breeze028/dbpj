using SIMS.Entity;
using SIMS.Utils.Controls;

namespace SIMS.WebApi.Services.Course
{
    public interface ICourseAppService
    {
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="teacher"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedRequest<CourseEntity> GetCourses(string courseName,string teacher, int pageNum,int pageSize);

        /// <summary>
        /// 通过id查询课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseEntity GetCourse(int id);

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public int AddCourse(CourseEntity course);

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public int UpdateCourse(CourseEntity course);

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id"></param>
        public int DeleteCourse(int id);
    }
}
