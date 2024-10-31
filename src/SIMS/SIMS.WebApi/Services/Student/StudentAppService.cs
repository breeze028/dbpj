using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Data;
using System.Linq.Expressions;

namespace SIMS.WebApi.Services.Student
{
    public class StudentAppService : IStudentAppService
    {
        private DataContext dataContext;

        public StudentAppService(DataContext dataContext) { 
            this.dataContext = dataContext;
        }

        /// <summary>
        /// 新增学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(StudentEntity student)
        {
            var entry = dataContext.Students.Add(student);
            dataContext.SaveChanges();
            return 0;
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id"></param>
        public int DeleteStudent(int id)
        {
            var entity = dataContext.Students.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Students.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// 查询学生列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum">页数</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        public PagedRequest<StudentEntity> GetStudents(string no,string name,int pageNum,int pageSize)
        {
            IQueryable<StudentEntity> students = null;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(no))
            {
                students = dataContext.Students.Where(r => r.Name.Contains(name) && r.No.Contains(no)).OrderBy(r => r.Id);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                students = dataContext.Students.Where(r => r.Name.Contains(name)).OrderBy(r => r.Id);
            }
            else if (!string.IsNullOrEmpty(no)) {
                students = dataContext.Students.Where(r => r.No.Contains(no)).OrderBy(r => r.Id);
            }
            else
            {
                students = dataContext.Students.Where(r => true).OrderBy(r => r.Id);
            }
            int count = students.Count();
            List<StudentEntity> items;
            if (pageSize > 0)
            {
                items = students.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else {
                items = students.ToList();
            }
            return new PagedRequest<StudentEntity>()
            {
                count = count,
                items = items
            };
        }

        /// <summary>
        /// 查询某一班级的学生列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public PagedRequest<StudentEntity> GetStudentsByClasses(int classId)
        {
            IQueryable<StudentEntity> students = dataContext.Students.Where(r => r.ClassesId==classId).OrderBy(r => r.Id);
            int count = students.Count();
            var items = students.ToList();
            return new PagedRequest<StudentEntity>()
            {
                count = count,
                items = items
            };
        }

        /// <summary>
        /// 通过id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentEntity GetSudent(int id)
        {
            var entity = dataContext.Students.FirstOrDefault(r => r.Id == id);
            return entity;
        }

        /// <summary>
        /// 修改学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(StudentEntity student)
        {
            dataContext.Students.Update(student);
            dataContext.SaveChanges();
            return 0;
        }
    }
}
