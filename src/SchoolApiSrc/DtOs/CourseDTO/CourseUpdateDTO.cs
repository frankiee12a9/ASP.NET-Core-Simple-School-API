using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.CourseDTO
{
    public class CourseUpdateDTO
    {
        public int CourseId { get; set; }
        [Required, MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}