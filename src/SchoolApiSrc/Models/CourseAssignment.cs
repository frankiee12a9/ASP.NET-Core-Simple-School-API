using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApiSrc.Models
{
    public class CourseAssignment
    {
        public int Id { get; set; }
        [ForeignKey("Lecturer")]
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}