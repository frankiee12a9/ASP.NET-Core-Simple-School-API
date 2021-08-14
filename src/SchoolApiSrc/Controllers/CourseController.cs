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
    [Route("api/[controller]")]
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
            var course = await _unitOfWork.CourseService
                .GetFirstOrDefault(
                    filter: c => c.CourseId == id,
                    includeProperties: "Department"
                );

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

        [HttpPut("{id}")]
        public ActionResult PutCourse(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.CourseService.Update(id);
                _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError(nameof(PutCourse), "unable to save changes");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult PatchCourse(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var courseToRemove = await _unitOfWork.CourseService.Get(id);
            try
            {
                _unitOfWork.CourseService.Remove(courseToRemove);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError("unable to save changes", nameof(DeleteCourse));
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] Course course)
        {

            // NOTE: When add new course with the `custom ID as auto increment` 
            // DON'T add the ID. Just add all other properties WITHOUT ID. 
            // EF Core will automatically add the ID with advancing of 1 for you.

            // If you ignore preceding NOTE and insert ID field when adding new course
            // you will FAILED without specified error from the system! 
            var newCourse = new Course
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                DepartmentId = course.DepartmentId
            };

            try
            {
                await _unitOfWork.CourseService.Create(newCourse);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(PostCourse), ex.Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute(nameof(GetCourseById), new { courseId = newCourse.CourseId }, newCourse);
        }
    }
}
