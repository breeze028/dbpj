using SIMS.Entity;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.StudentModule.Models
{
    public class StudentInfo:StudentEntity
    {
        public StudentInfo() { 
        
        }

        public StudentInfo(StudentEntity entity) { 
            this.Id = entity.Id;
            this.Age = entity.Age;
            this.ClassesId = entity.ClassesId;
            this.Sex = entity.Sex;
            this.LastEditTime = entity.LastEditTime;
            this.CreateTime = entity.CreateTime;
            this.Name = entity.Name;
            this.LastEditUser = entity.LastEditUser;
            this.CreateUser = entity.CreateUser;
            this.No=entity.No;
        }

        private string classesName=String.Empty;

        public string ClassesName
        {
            get
            {
                if (string.IsNullOrEmpty(classesName))
                {
                    if (this.ClassesId > 0)
                    {
                        var classes = ClassesHttpUtil.GetClasses(this.ClassesId.GetValueOrDefault());
                        this.classesName = $"{classes.Dept}|{classes.Grade}|{classes.Name}";
                    }
                }
                return classesName;
            }
        }

        
        public bool IsBoy
        {
            get { return Sex; }
            set { Sex = value; }
        }

        public bool IsGirl
        {
            get { return !Sex; }
            set { Sex=!value; }
        }
    }
}
