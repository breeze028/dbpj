using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Entity
{
    /// <summary>
    /// 角色-菜单关联
    /// </summary>
    public class RoleMenuEntity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜单IP
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
    }
}
