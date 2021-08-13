using System;
using SchoolApiSrc.Data;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly SchoolContext _context;

        public StudentService(SchoolContext context) : base(context)
        {
            _context = context;
        }
    }
}