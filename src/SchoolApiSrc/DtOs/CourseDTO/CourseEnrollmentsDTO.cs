
using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.CourseDTO
{
    public class CourseEnrollmentsDTO
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}