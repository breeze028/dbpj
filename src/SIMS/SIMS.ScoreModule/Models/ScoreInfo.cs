using SIMS.Entity;
using SIMS.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ScoreModule.Models
{
    public class ScoreInfo:ScoreEntity
    {
        public ScoreInfo(ScoreEntity entity)
        {
            this.Id = entity.Id;
            this.CourseId = entity.CourseId;
            this.Score = entity.Score;
            this.StudentId = entity.StudentId;
            this.CreateUser = entity.CreateUser;
            this.LastEditUser = entity.LastEditUser;
            this.CreateTime = entity.CreateTime;
            this.LastEditTime = entity.LastEditTime;
        }

        private StudentEntity student;

        public StudentEntity Student
        {
            get
            {
                if (student == null)
                {
                    student = StudentHttpUtil.GetStudent(StudentId);
                }
                return student;
            }
        }


        private CourseEntity course;

        public CourseEntity Course
        {
            get
            {
                if (course == null)
                {
                    course = CourseHttpUtil.GetCourse(CourseId);
                }
                return course;
            }
        }

    }
}
