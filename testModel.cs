using System;


namespace schoolApi
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudentType { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }

    public class Lecturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LecturerType { get; set; }
        [Foreignkey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseAssignment> CourseAssignment { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }

    public class CourseEnrollment
    {
        public int StudnetId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class CourseAssignment
    {
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class Department

    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Icollection<Student> Students { get; set; }

        public Icollection<Lecturer> Lecturers { get; set; }
        public Icollection<Course> Courses { get; set; }
    }


}