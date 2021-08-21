using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.AppAuthDTO
{
    public class AppRegisterDTO
    {
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string Password { get; set; }
    }
}