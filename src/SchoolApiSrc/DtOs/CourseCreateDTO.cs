using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs
{
    public class CourseCreateDTO
    {
        [Required, MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}