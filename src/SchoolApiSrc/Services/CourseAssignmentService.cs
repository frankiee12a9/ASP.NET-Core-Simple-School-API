using System;
using SchoolApiSrc.Data;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Services
{
    public class CourseAssigmentService : Service<CourseAssignment>, ICourseAssignmentService
    {
        private readonly SchoolContext _context;

        public CourseAssigmentService(SchoolContext context) : base(context)
        {
            _context = context;
        }
    }
}