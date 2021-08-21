using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApiSrc.Models
{
    public class AppLoginInfo
    {
        [Key]
        public int AppLoginId { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public string JwtKey { get; set; }
    }
}