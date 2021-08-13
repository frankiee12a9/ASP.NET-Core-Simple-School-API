using System;
using System.Text;
using SchoolApiSrc.Services;
using System.Collections.Generic;
using SchoolApiSrc.Services.IServices;
using System.Threading.Tasks;
using SchoolApiSrc.Data;

namespace SchoolApiSrc.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICourseService CourseService { get; private set; }
        public IStudentService StudentService { get; private set; }

        public ILectureService LecturerService { get; private set; }

        public IDepartmentService DepartmentService { get; private set; }

        private readonly SchoolContext _context;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            CourseService = new CourseService(_context);
            StudentService = new StudentService(_context);
            LecturerService = new LecturerService(_context);
            DepartmentService = new DepartmentService(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}