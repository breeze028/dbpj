
using Microsoft.EntityFrameworkCore;
using SIMS.Entity;


namespace SIMS.WebApi.Data
{
    public class DataContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<MenuEntity> Menus { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<UserRoleEntity> UserRoles { get; set; }

        public DbSet<RoleMenuEntity> RoleMenus { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public DbSet<StudentEntity> Students { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public DbSet<ClassesEntity> Classes { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public DbSet<CourseEntity> Courses { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        public DbSet<ScoreEntity> Scores { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<MenuEntity>().ToTable("Menus");
            modelBuilder.Entity<StudentEntity>().ToTable("Students");
            modelBuilder.Entity<RoleEntity>().ToTable("Roles");
            modelBuilder.Entity<UserRoleEntity>().ToTable("UserRoles");
            modelBuilder.Entity<RoleMenuEntity>().ToTable("RoleMenus");
        }
    }
}
