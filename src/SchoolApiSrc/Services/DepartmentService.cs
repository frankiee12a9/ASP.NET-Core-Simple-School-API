using System;
using SchoolApiSrc.Data;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Services
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly SchoolContext _context;

        public DepartmentService(SchoolContext context) : base(context)
        {
            _context = context;
        }
    }
}