using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Entity
{
    /// <summary>
    /// 班级实体
    /// </summary>
    public class ClassesEntity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 班主任老师名称
        /// </summary>
        public string HeadTeacher { get; set; }

        /// <summary>
        /// 班长id，对应学生表的学生
        /// </summary>
        public int? Monitor { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 当前登录的账号的ID
        /// </summary>
        public int CreateUser { get; set; }

        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime LastEditTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int LastEditUser { get; set; }
    }
}
