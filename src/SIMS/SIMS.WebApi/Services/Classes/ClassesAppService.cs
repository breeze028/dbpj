using SIMS.Entity;
using SIMS.Utils.Controls;
using SIMS.WebApi.Data;

namespace SIMS.WebApi.Services.Classes
{
    public class ClassesAppService : IClassesAppService
    {
        private DataContext dataContext;

        public ClassesAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// 新增班级
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public int AddClasses(ClassesEntity classes)
        {
            var entry = dataContext.Classes.Add(classes);
            dataContext.SaveChanges();
            return 0;
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="id"></param>
        public int DeleteClasses(int id)
        {
            var entity = dataContext.Classes.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Classes.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// 查询班级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClassesEntity GetClasses(int id)
        {
            var entity = dataContext.Classes.FirstOrDefault(r => r.Id == id);
            return entity;
        }

        public PagedRequest<ClassesEntity> GetClassess(string dept, string grade, int pageNum, int pageSize)
        {
            IQueryable<ClassesEntity> classes = null;
            if (!string.IsNullOrEmpty(dept) && string.IsNullOrEmpty(grade))
            {
                classes = dataContext.Classes.Where(r => r.Dept.Contains(dept) && r.Grade.Contains(grade)).OrderBy(r => r.Id);
            }
            else if (!string.IsNullOrEmpty(dept))
            {
                classes = dataContext.Classes.Where(r => r.Dept.Contains(dept)).OrderBy(r => r.Id);
            }
            else if (!string.IsNullOrEmpty(grade))
            {
                classes = dataContext.Classes.Where(r => r.Grade.Contains(grade)).OrderBy(r => r.Id);
            }
            else
            {
                classes = dataContext.Classes.Where(r => true).OrderBy(r => r.Id);
            }
            int count = classes.Count();
            List<ClassesEntity> items=new List<ClassesEntity>();
            if (pageSize < 1)
            {
                items = classes.ToList();
            }
            else { 
               items = classes.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            
            return new PagedRequest<ClassesEntity>()
            {
                count = count,
                items = items
            };
        }

        /// <summary>
        /// 修改班级
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public int UpdateClasses(ClassesEntity classes)
        {
            dataContext.Classes.Update(classes);
            dataContext.SaveChanges();
            return 0;
        }
    }
}
