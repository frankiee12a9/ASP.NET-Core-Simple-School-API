using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApiSrc.DTOs.LecturerDTO
{
    public class LecturerReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LecturerType { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int AssignedCourses { get; set; }
        public List<Dictionary<string, string>> DictCourses { get; set; } = new List<Dictionary<string, string>>();
    }
}