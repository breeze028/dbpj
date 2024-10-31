using SIMS.Entity;
using SIMS.Utils.Controls;

namespace SIMS.WebApi.Services.Student
{
    public interface IStudentAppService
    {
        /// <summary>
        /// 查询学生列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PagedRequest<StudentEntity> GetStudents(string no,string name, int pageNum, int pageSize);

        /// <summary>
        /// 查询某一班级的学生列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public PagedRequest<StudentEntity> GetStudentsByClasses(int classId);

        /// <summary>
        /// 通过id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentEntity GetSudent(int id);

        /// <summary>
        /// 新增学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(StudentEntity student);

        /// <summary>
        /// 修改学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(StudentEntity student);

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id"></param>
        public int DeleteStudent(int id);
    }
}
