using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class CourseHttpUtil:HttpUtil
    {
        /// <summary>
        /// 通过id查询课程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CourseEntity GetCourse(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.COURSE_GETCOURSE, data);
            var course = StrToObject<CourseEntity>(str);
            return course;
        }

        public static PagedRequest<CourseEntity> GetCourses(string? courseName, string? teacher, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["courseName"] = courseName;
            data["teacher"] = teacher;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.COURSE_GETCOURSES, data);
            var courses = StrToObject<PagedRequest<CourseEntity>>(str);
            return courses;
        }

        public static bool AddCourse(CourseEntity course)
        {
            var ret = Post<CourseEntity>(UrlConfig.COURSE_ADDCOURSE, course);
            return int.Parse(ret) == 0;
        }

        public static bool UpdateCourse(CourseEntity course)
        {
            var ret = Put<CourseEntity>(UrlConfig.COURSE_UPDATECOURSE, course);
            return int.Parse(ret) == 0;
        }

        public static bool DeleteCourse(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.COURSE_DELETECOURSE, data);
            return int.Parse(ret) == 0;
        }
    }
}
