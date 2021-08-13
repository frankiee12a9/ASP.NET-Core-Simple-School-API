using System;
using System.Linq;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.Data
{
    public static class DBInitialier
    {
        public static void InitializeDB(SchoolContext db)
        {
            db.Database.EnsureCreated();

            if (db.Departments.Any())
            {
                return;
            }

            var departments = new Department[]
            {
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
                },
            };

            db.Departments.AddRange(departments);
            db.SaveChanges();

            var stdudents = new Student[]
            {
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
                },
             };


            db.Students.AddRange(stdudents);
            db.SaveChanges();


            var lecturers = new Lecturer[]
            {
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
                },
            };

            db.Lecturers.AddRange(lecturers);
            db.SaveChanges();

            var courses = new Course[]
            {
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
                },
            };

            db.Courses.AddRange(courses);
            db.SaveChanges();

            var courseAssignments = new CourseAssignment[]
            {
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
            };

            db.CourseAssignments.AddRange(courseAssignments);
            db.SaveChanges();

            var courseEnrollemnts = new CourseEnrollment[]
            {
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
                },
            };

            db.courseEnrollments.AddRange(courseEnrollemnts);
            db.SaveChanges();

        }
    }
}