using System;
using SchoolApiSrc.Data;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly SchoolContext _context;

        public CourseService(SchoolContext context) : base(context)
        {
            _context = context;
        }
    }
}