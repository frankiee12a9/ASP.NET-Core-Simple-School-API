using System;
using Microsoft.EntityFrameworkCore;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CourseEnrollment> courseEnrollments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Department>().HasData(
              new Department
              {
                  DepartmentId = 4000,
                  DepartmentName = "Computer Science Dept"
              },
                new Department
                {
                    DepartmentId = 4001,
                    DepartmentName = "Mathematics Dept"
                },
                new Department
                {
                    DepartmentId = 4002,
                    DepartmentName = "Business and Language Dept"
                }
            );

            builder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 3000,
                    CourseName = "Data Structure",
                    DepartmentId = 4000
                },

                 new Course
                 {
                     CourseId = 3001,
                     CourseName = "Calculus",
                     DepartmentId = 4001,
                 },

                new Course
                {
                    CourseId = 3002,
                    CourseName = "English Conversation",
                    DepartmentId = 4002
                }
            );

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1000,
                    Name = "Student1",
                    Email = "st1@abc.com",
                    StudentType = "Freshman",
                    DepartmentId = 4000
                },

                new Student
                {
                    Id = 1001,
                    Name = "Student2",
                    Email = "st2@abc.com",
                    StudentType = "Junior",
                    DepartmentId = 4001
                },

                new Student
                {
                    Id = 1002,
                    Name = "Student3",
                    Email = "st3@abc.com",
                    StudentType = "Senior",
                    DepartmentId = 4002
                }
            );

            builder.Entity<Lecturer>().HasData(
                new Lecturer
                {
                    Id = 2000,
                    Name = "Kim",
                    Email = "kim@kkk.com",
                    LecturerType = "Professor",
                    DepartmentId = 4000
                },
                new Lecturer
                {
                    Id = 2001,
                    Name = "Lee",
                    Email = "lee@kkk.com",
                    LecturerType = "Professor",
                    DepartmentId = 4001
                },
                new Lecturer
                {
                    Id = 2002,
                    Name = "Park",
                    Email = "park@kkk.com",
                    LecturerType = "Professor",
                    DepartmentId = 4002
                }
            );


            builder.Entity<CourseAssignment>().HasData(
                new CourseAssignment
                {
                    LecturerId = 2000,
                    CourseId = 3000
                },

                new CourseAssignment
                {
                    LecturerId = 2001,
                    CourseId = 3001
                },

                new CourseAssignment
                {
                    LecturerId = 2002,
                    CourseId = 3002
                }
            );

            builder.Entity<CourseEnrollment>().HasData(
                new CourseEnrollment
                {
                    CourseId = 3000,
                    StudentId = 1000
                },

                new CourseEnrollment
                {
                    CourseId = 3001,
                    StudentId = 1001
                },
                new CourseEnrollment
                {
                    CourseId = 3002,
                    StudentId = 1002
                }
            );

            builder.Entity<Course>()
                .HasOne(d => d.Department)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CourseAssignment>()
                .HasKey(p => new { p.CourseId, p.LecturerId });

            builder.Entity<CourseAssignment>()
                .HasOne(p => p.Course)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(fk => fk.CourseId);

            builder.Entity<CourseAssignment>()
                .HasOne(p => p.Lecturer)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(fk => fk.LecturerId);

            builder.Entity<CourseEnrollment>()
                .HasKey(e => new { e.CourseId, e.StudentId });

            builder.Entity<CourseEnrollment>()
                .HasOne(p => p.Course)
                .WithMany(p => p.CourseEnrollments)
                .HasForeignKey(fk => fk.CourseId);

            builder.Entity<CourseEnrollment>()
                .HasOne(p => p.Student)
                .WithMany(p => p.CourseEnrollments)
                .HasForeignKey(fk => fk.StudentId);
        }
    }
}