using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineVideoCourseWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace OnlineVideoCourseWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OnlineVideoCourseWebsite.Models.Course> Course { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.User> User { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.Video> Video { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.Resource> Resource { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.Topic> Topic { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.Enrollment> Enrollment { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.Comment> Comment { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.CourseOffering> CourseOffering { get; set; }
        public DbSet<OnlineVideoCourseWebsite.Models.TopicVideo> TopicVideo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "Instructor",
                NormalizedName = "INSTRUCTOR"
            },
            new IdentityRole
            {
                //Id = Guid.NewGuid().ToString(),
                Id = "3",
                Name = "Student",
                NormalizedName = "STUDENT"
            }
            );
        }
    }
}