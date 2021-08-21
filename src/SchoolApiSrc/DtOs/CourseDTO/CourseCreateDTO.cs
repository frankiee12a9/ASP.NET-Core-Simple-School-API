using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.CourseDTO
{
    public class CourseCreateDTO
    {
        [Required, MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}