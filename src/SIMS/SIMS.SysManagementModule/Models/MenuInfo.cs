using SIMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SysManagementModule.Models
{
    public class MenuInfo:MenuEntity
    {
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        public MenuInfo(MenuEntity entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Icon = entity.Icon;
            this.ParentId=entity.ParentId;
            this.SortId = entity.SortId;
            this.Url = entity.Url;
        }
    }
}
