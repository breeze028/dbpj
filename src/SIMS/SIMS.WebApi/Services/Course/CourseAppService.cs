using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Data;

namespace SIMS.WebApi.Services.Course
{
    public class CourseAppService : ICourseAppService
    {
        private DataContext dataContext;

        public CourseAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int AddCourse(CourseEntity course)
        {
            var entry = dataContext.Courses.Add(course);
            dataContext.SaveChanges();
            return 0;
        }

        public int DeleteCourse(int id)
        {
            var entity = dataContext.Courses.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Courses.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// 根据ID获取单个课程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseEntity GetCourse(int id)
        {
            var entity = dataContext.Courses.FirstOrDefault(r => r.Id == id);
            return entity;
        }

        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="teacher"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedRequest<CourseEntity> GetCourses(string courseName, string teacher, int pageNum, int pageSize)
        {
            IQueryable<CourseEntity> courses = null;
            if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(teacher))
            {
                courses = dataContext.Courses.Where(r => r.Name.Contains(courseName) && r.Teacher.Contains(teacher)).OrderBy(r => r.Id);
            }
            else if (!string.IsNullOrEmpty(courseName))
            {
                courses = dataContext.Courses.Where(r => r.Name.Contains(courseName)).OrderBy(r => r.Id);
            }
            else if (!string.IsNullOrEmpty(teacher))
            {
                courses = dataContext.Courses.Where(r => r.Teacher.Contains(teacher)).OrderBy(r => r.Id);
            }
            else
            {
                courses = dataContext.Courses.Where(r => true).OrderBy(r => r.Id);
            }
            int count = courses.Count();
            List<CourseEntity> items;
            if (pageSize > 0)
            {
                items = courses.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = courses.ToList();
            }
            return new PagedRequest<CourseEntity>()
            {
                count = count,
                items = items
            };
        }

        public int UpdateCourse(CourseEntity course)
        {
            dataContext.Courses.Update(course);
            dataContext.SaveChanges();
            return 0;
        }
    }
}
