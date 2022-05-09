﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _V2__OnlineVideoCourseWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace _V2__OnlineVideoCourseWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.Course> Course { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.User> User { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.Video> Video { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.Resource> Resource { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.Topic> Topic { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.Enrollment> Enrollment { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.Comment> Comment { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.CourseOffering> CourseOffering { get; set; }
        public DbSet<_V2__OnlineVideoCourseWebsite.Models.TopicVideo> TopicVideo { get; set; }

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
                Name = "Teacher",
                NormalizedName = "TEACHER"
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