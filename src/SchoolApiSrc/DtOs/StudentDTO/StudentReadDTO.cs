using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.DTOs.StudentDTO
{
    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudentType { get; set; }
        public int DepartmentID { get; set; }
        public int EnrolledCourses { get; set; }

        // public int CourseID { get; set; }
        // public string CourseName { get; set; }
        // public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}