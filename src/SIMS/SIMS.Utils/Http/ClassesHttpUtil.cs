using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class ClassesHttpUtil:HttpUtil
    {
        /// <summary>
        /// 通过id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClassesEntity GetClasses(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.CLASSES_GETCLASSES, data);
            var classes = StrToObject<ClassesEntity>(str);
            return classes;
        }

        public static PagedRequest<ClassesEntity> GetClassess(string? dept, string? grade, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["dept"] = dept;
            data["grade"] = grade;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.CLASSES_GETCLASSESS, data);
            var classess = StrToObject<PagedRequest<ClassesEntity>>(str);
            return classess;
        }

        public static bool AddClasses(ClassesEntity classes) {
            var ret = Post<ClassesEntity>(UrlConfig.CLASSES_ADDCLASSES, classes);
            return int.Parse(ret)==0;
        }

        public static bool UpdateClasses(ClassesEntity classes) {
            var ret = Put<ClassesEntity>(UrlConfig.CLASSES_UPDATECLASSES, classes);
            return int.Parse(ret) == 0;
        }

        public static bool DeleteClasses(int Id)
        {
            Dictionary<string,  string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.CLASSES_DELETECLASSES, data);
            return int.Parse(ret) == 0;
        }
    }
}
