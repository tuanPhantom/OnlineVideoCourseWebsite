﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _V2__OnlineVideoCourseWebstie.Data;

#nullable disable

namespace _V2__OnlineVideoCourseWebstie.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220426032247_v8")]
    partial class v8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CommentId"), 1L, 1);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("VideoId")
                        .HasColumnType("bigint");

                    b.HasKey("CommentId");

                    b.HasIndex("UserId1");

                    b.HasIndex("VideoId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Course", b =>
                {
                    b.Property<long>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CourseId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MarqueeImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("CourseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.CourseOffering", b =>
                {
                    b.Property<long>("CourseOfferingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CourseOfferingId"), 1L, 1);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CourseOfferingId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseOffering");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Enrollment", b =>
                {
                    b.Property<long>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EnrollmentId"), 1L, 1);

                    b.Property<long?>("CourseOfferingId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseOfferingId");

                    b.HasIndex("UserId1");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Resource", b =>
                {
                    b.Property<long>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ResourceId"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TopicId")
                        .HasColumnType("bigint");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceId");

                    b.HasIndex("TopicId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Topic", b =>
                {
                    b.Property<long>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TopicId"), 1L, 1);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.HasIndex("CourseId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.TopicVideo", b =>
                {
                    b.Property<long>("TopicVideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TopicVideoId"), 1L, 1);

                    b.Property<long?>("TopicId")
                        .HasColumnType("bigint");

                    b.Property<long?>("VideoId")
                        .HasColumnType("bigint");

                    b.HasKey("TopicVideoId");

                    b.HasIndex("TopicId");

                    b.HasIndex("VideoId");

                    b.ToTable("TopicVideo");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Video", b =>
                {
                    b.Property<long>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VideoId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TopicId")
                        .HasColumnType("bigint");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoId");

                    b.HasIndex("TopicId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "02e63747-ffcd-4a69-84d6-360a846b1d7e",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "d9f7badb-f0df-4de8-9acf-331c3c679d05",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "2fff25a9-19a8-46ad-8351-1d8df730219a",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Comment", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("VideoId");

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.CourseOffering", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Course", "Course")
                        .WithMany("CourseOfferings")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Enrollment", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.CourseOffering", "CourseOffering")
                        .WithMany()
                        .HasForeignKey("CourseOfferingId");

                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.User", "User")
                        .WithMany("Enrollments")
                        .HasForeignKey("UserId1");

                    b.Navigation("CourseOffering");

                    b.Navigation("User");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Resource", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Topic", "Topic")
                        .WithMany("Resources")
                        .HasForeignKey("TopicId");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Topic", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.TopicVideo", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Topic", "Topic")
                        .WithMany("TopicVideos")
                        .HasForeignKey("TopicId");

                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Video", "Video")
                        .WithMany("TopicVideo")
                        .HasForeignKey("VideoId");

                    b.Navigation("Topic");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Video", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.Topic", null)
                        .WithMany("Videos")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("_V2__OnlineVideoCourseWebstie.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Course", b =>
                {
                    b.Navigation("CourseOfferings");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Topic", b =>
                {
                    b.Navigation("Resources");

                    b.Navigation("TopicVideos");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.User", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("_V2__OnlineVideoCourseWebstie.Models.Video", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TopicVideo");
                });
#pragma warning restore 612, 618
        }
    }
}
