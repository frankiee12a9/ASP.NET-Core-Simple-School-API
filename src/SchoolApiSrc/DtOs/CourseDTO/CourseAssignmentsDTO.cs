using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.CourseDTO
{
    public class CourseAssignmentsDTO
    {
        [Required]
        public int LecturerId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}