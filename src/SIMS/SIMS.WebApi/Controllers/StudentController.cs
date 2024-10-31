using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Services.Student;

namespace SIMS.WebApi.Controllers
{
    /// <summary>
    /// 学生控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;

        private readonly IStudentAppService studentAppService;

        public StudentController(ILogger<StudentController> logger, IStudentAppService studentAppService) {
            this.logger = logger;
            this.studentAppService = studentAppService;
        }

        /// <summary>
        /// 学生列表，带分页
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<StudentEntity> GetStudents(int pageNum, int pageSize,string? no = null ,string? name=null ) { 
            return studentAppService.GetStudents(no,name, pageNum, pageSize);
        }

        /// <summary>
        /// 查询某一班级的学生列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpGet]
        public PagedRequest<StudentEntity> GetStudentsByClasses(int classId) {
            return studentAppService.GetStudentsByClasses(classId);
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public StudentEntity GetStudent(int id) {
            return studentAppService.GetSudent(id);
        }

        /// <summary>
        /// 新增学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddStudent(StudentEntity student)
        {
            return studentAppService.AddStudent(student);
        }

        /// <summary>
        /// 修改学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateStudent(StudentEntity student) { 
            return studentAppService.UpdateStudent(student);
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public int DeleteStudent(int id)
        {
            return studentAppService.DeleteStudent(id);
        }
    }
}
