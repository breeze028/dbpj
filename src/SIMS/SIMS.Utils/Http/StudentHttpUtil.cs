using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    /// <summary>
    /// 学生类Http访问通用类
    /// </summary>
    public class StudentHttpUtil:HttpUtil
    {
        /// <summary>
        /// 通过id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static StudentEntity GetStudent(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.STUDENT_GETSTUDENT, data);
            var student = StrToObject<StudentEntity>(str);
            return student;
        }

        public static PagedRequest<StudentEntity> GetStudents(string no,string name, int pageNum, int pageSize) {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["no"] = no;
            data["name"] = name;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.STUDENT_GETSTUDENTS, data);
            var students = StrToObject<PagedRequest<StudentEntity>>(str);
            return students;
        }

        public static PagedRequest<StudentEntity> GetStudentsByClasses(int? classId)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["classId"] = classId;
            var str = Get(UrlConfig.STUDENT_GETSTUDENTSBYCLASSES, data);
            var students = StrToObject<PagedRequest<StudentEntity>>(str);
            return students;
        }

        public static bool AddStudent(StudentEntity student)
        {
            var ret = Post<StudentEntity>(UrlConfig.STUDENT_ADDSTUDENT, student);
            return int.Parse(ret) == 0;
        }

        public static bool UpdateStudent(StudentEntity student)
        {
            var ret = Put<StudentEntity>(UrlConfig.STUDENT_UPDATESTUDENT, student);
            return int.Parse(ret) == 0;
        }

        public static bool DeleteStudent(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.STUDENT_DELETESTUDENT, data);
            return int.Parse(ret) == 0;
        }
    }
}
