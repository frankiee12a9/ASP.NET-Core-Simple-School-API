using System;
using SchoolApiSrc.Data;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Services
{
    public class CourseEnrollmentService : Service<CourseEnrollment>, ICourseEnrollmentService
    {
        private readonly SchoolContext _context;

        public CourseEnrollmentService(SchoolContext context) : base(context)
        {
            _context = context;
        }
    }
}