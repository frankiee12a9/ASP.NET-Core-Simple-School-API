using System;
using System.Threading.Tasks;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.Services.IServices
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseService CourseService { get; }
        IStudentService StudentService { get; }
        ILectureService LecturerService { get; }
        IDepartmentService DepartmentService { get; }
        Task SaveChangesAsync();
    }
}