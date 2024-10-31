namespace SIMS.Entity
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class StudentEntity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 学生名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年纪
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Boolean Sex { get; set; }

        /// <summary>
        /// 班级标识
        /// </summary>
        public int? ClassesId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 当前登录的账号的ID
        /// </summary>
        public int? CreateUser { get; set; }

        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime? LastEditTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastEditUser { get; set; }
    }
}