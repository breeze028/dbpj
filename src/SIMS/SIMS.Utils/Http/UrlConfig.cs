using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public static class UrlConfig
    {
        //学生管理

        public static string STUDENT_GETSTUDENT = "api/Student/GetStudent";

        public static string STUDENT_GETSTUDENTS = "api/Student/GetStudents";

        public static string STUDENT_GETSTUDENTSBYCLASSES = "api/Student/GetStudentsByClasses";

        public static string STUDENT_ADDSTUDENT = "api/Student/AddStudent";

        public static string STUDENT_UPDATESTUDENT = "api/Student/UpdateStudent";

        public static string STUDENT_DELETESTUDENT = "api/Student/DeleteStudent";

        //课程

        public static string COURSE_GETCOURSE = "api/Course/GetCourse";

        public static string COURSE_GETCOURSES = "api/Course/GetCourses";

        public static string COURSE_ADDCOURSE = "api/Course/AddCourse";

        public static string COURSE_UPDATECOURSE = "api/Course/UpdateCourse";

        public static string COURSE_DELETECOURSE = "api/Course/DeleteCourse";


        //成绩

        public static string SCORE_GETSCORE = "api/Score/GetScore";

        public static string SCORE_GETSCORES = "api/Score/GetScores";

        public static string SCORE_ADDSCORE = "api/Score/AddScore";

        public static string SCORE_UPDATESCORE = "api/Score/UpdateScore";

        public static string SCORE_DELETESCORE = "api/Score/DeleteScore";

        //班级

        public static string CLASSES_GETCLASSES = "api/Classes/GetClasses";

        public static string CLASSES_GETCLASSESS = "api/Classes/GetClassess";

        public static string CLASSES_ADDCLASSES = "api/Classes/AddClasses";

        public static string CLASSES_UPDATECLASSES = "api/Classes/UpdateClasses";

        public static string CLASSES_DELETECLASSES = "api/Classes/DeleteClasses";

        //用户
        public static string USER_GETUSERS = "api/User/GetUsers";

        public static string USER_GETUSER = "api/User/GetUser";

        public static string USER_ADDUSER = "api/User/AddUser";

        public static string USER_UPDATEUSER = "api/User/UpdateUser";

        public static string USER_DELETEUSER = "api/User/DeleteUser";

        public static string USER_GETUSERROLES = "api/User/GetUserRoles";

        public static string USER_SETUSERROLES = "api/User/SetUserRoles";

        //菜单
        public static string MENU_GETMENU = "api/Menu/GetMenu";

        public static string MENU_GETMENUS = "api/Menu/GetMenus";

        public static string MENU_ADDMENU = "api/Menu/AddMenu";

        public static string MENU_UPDATEMENU = "api/Menu/UpdateMenu";

        public static string MENU_DELETEMENU = "api/Menu/DeleteMenu";

        //角色
        public static string ROLE_GETROLE = "api/Role/GetRole";

        public static string ROLE_GETROLES = "api/Role/GetRoles";

        public static string ROLE_GETROLEMENUS = "api/Role/GetRoleMenus";

        public static string ROLE_SETROLEMENUS = "api/Role/SetRoleMenus";

        public static string ROLE_ADDROLE = "api/Role/AddRole";

        public static string ROLE_UPDATEROLE = "api/Role/UpdateRole";

        public static string ROLE_DELETEROLE = "api/Role/DeleteRole";

        public static string ROLE_GETUSERRIGHTS = "api/Role/GetUserRights";

        //logIn
        public static string LOGIN_LOGIN = "api/Login/Login";
    }
}
