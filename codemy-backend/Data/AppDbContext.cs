using Microsoft.EntityFrameworkCore;

namespace codemy_backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }
        public DbSet<UserModel> Users {get; set;}
        public DbSet<CourseModel> Courses {get; set;}
        public DbSet<LessonModel> Lessons {get; set;}
        public DbSet<EnrollmentModel> Enrollments {get; set;}
        public DbSet<ReviewModel> Reviews {get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new LessonMap());
            modelBuilder.ApplyConfiguration(new EnrollmentMap());
            modelBuilder.ApplyConfiguration(new ReviewMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}