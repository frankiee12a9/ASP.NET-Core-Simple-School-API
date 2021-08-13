using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApiSrc.Models
{
    public class CourseEnrollment
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}