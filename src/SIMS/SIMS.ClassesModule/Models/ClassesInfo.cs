using SIMS.Entity;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ClassesModule.Models
{
    public class ClassesInfo:ClassesEntity
    {
        public ClassesInfo() { 
        
        }

        public ClassesInfo(ClassesEntity classes)
        {
            this.Id = classes.Id;
            this.Dept=classes.Dept;
            this.Name = classes.Name;
            this.Grade = classes.Grade;
            this.HeadTeacher = classes.HeadTeacher;
            this.Monitor = classes.Monitor;
            this.LastEditTime = classes.LastEditTime;
            this.LastEditUser = classes.LastEditUser;
            this.CreateTime = classes.CreateTime;
            this.CreateUser = classes.CreateUser;
            
        }

        private string monitorName =string.Empty;

        public string MonitorName
        {
            get
            {
                if (string.IsNullOrEmpty(monitorName) && Monitor > 0)
                {
                    var student = StudentHttpUtil.GetStudent(Monitor.GetValueOrDefault());
                    monitorName = student.Name;
                }
                return monitorName;
            }
        }
    }
}
