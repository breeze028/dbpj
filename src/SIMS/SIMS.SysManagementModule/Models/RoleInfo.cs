using Prism.Mvvm;
using SIMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.SysManagementModule.Models
{
    public class RoleInfo:RoleEntity
    {
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set {  isChecked = value; }
        }

        public RoleInfo(RoleEntity entity) { 
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
        }
    }
}
