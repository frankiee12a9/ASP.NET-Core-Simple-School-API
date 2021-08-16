using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.StudentDTO
{
    public class StudentCreateDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string StudentType { get; set; }
        public int DepartmentID { get; set; }
    }
}