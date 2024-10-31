using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Entity
{
    /// <summary>
    /// 成绩实体
    /// </summary>
    public class ScoreEntity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///学生id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// 课程id
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        public double Score { get; set; }

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
