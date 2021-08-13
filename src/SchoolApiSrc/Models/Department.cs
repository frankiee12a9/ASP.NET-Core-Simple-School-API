using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Lecturer> Lecturers { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}