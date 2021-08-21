using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.AppAuthDTO
{
    public class AppLoginDTO
    {
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string JwtKey { get; set; }
    }
}