using System;
using SchoolApiSrc.Data;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Services
{
    public class LecturerService : Service<Lecturer>, ILectureService
    {
        private readonly SchoolContext _context;

        public LecturerService(SchoolContext context) : base(context)
        {
            _context = context;
        }
    }
}