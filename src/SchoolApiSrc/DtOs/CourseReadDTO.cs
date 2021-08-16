using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.DTOs
{
    public class CourseReadDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int Enrollemnts { get; set; }
        public int LecturersNumber { get; set; }

        // public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        // public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}