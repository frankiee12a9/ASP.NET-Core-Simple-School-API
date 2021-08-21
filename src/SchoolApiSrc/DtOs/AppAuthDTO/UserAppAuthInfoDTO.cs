using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.AppAuthDTO
{
    public class UserAppAuthInfoDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
    }
}