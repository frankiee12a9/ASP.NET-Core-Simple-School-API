using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CourseController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _unitOfWork.CourseService.Get(id);
            if (course is null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var courses = await _unitOfWork.CourseService.GetAll(includeProperties: "Department");
            return Ok(courses);
        }


    }
}
