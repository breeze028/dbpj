using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Data;

namespace SIMS.WebApi.Services.Score
{
    public class ScoreAppService : IScoreAppService
    {
        private DataContext dataContext;

        public ScoreAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int AddScore(ScoreEntity score)
        {
            var entity = this.dataContext.Scores.Add(score);
            this.dataContext.SaveChanges();
            return 0;
        }

        public int DeleteScore(int id)
        {
            var entity = dataContext.Scores.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Scores.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }

        public ScoreEntity GetScore(int id)
        {
            var entity = dataContext.Scores.FirstOrDefault(r => r.Id == id);
            return entity;
        }

        /// <summary>
        /// 按条件查询成绩列表
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="courseName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedRequest<ScoreEntity> GetScores(string studentName, string courseName, int pageNum, int pageSize)
        {
            IQueryable<ScoreEntity> scores = null;
            if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(courseName))
            {
                var students = this.dataContext.Students.Where(r => r.Name.Contains(studentName));
                var courses = this.dataContext.Courses.Where(r => r.Name.Contains(courseName));
                scores = this.dataContext.Scores.Where(r => students.Select(t => t.Id).Contains(r.StudentId)).Where(r => courses.Select(t => t.Id).Contains(r.CourseId));
            }
            else if (!string.IsNullOrEmpty(studentName))
            {
                var students = this.dataContext.Students.Where(r => r.Name.Contains(studentName));
                scores = this.dataContext.Scores.Where(r => students.Select(t => t.Id).Contains(r.StudentId));
            }
            else if (!string.IsNullOrEmpty(courseName))
            {
                var courses = this.dataContext.Courses.Where(r => r.Name.Contains(courseName));
                scores = this.dataContext.Scores.Where(r => courses.Select(t => t.Id).Contains(r.CourseId));
            }
            else {
                scores = dataContext.Scores.Where(r => true).OrderBy(r => r.Id);
            }
            int count = scores.Count();
            List<ScoreEntity> items;
            if (pageSize > 0)
            {
                items = scores.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = scores.ToList();
            }
            return new PagedRequest<ScoreEntity>()
            {
                count = count,
                items = items
            };
        }

        public int UpdateScore(ScoreEntity score)
        {
            dataContext.Scores.Update(score);
            dataContext.SaveChanges();
            return 0;
        }
    }
}
