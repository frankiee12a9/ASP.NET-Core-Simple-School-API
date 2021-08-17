using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.LecturerDTO
{
    public class LecturerCreateDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string LecturerType { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}