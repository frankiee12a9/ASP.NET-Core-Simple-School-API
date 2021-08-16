using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolApiSrc.DTOs;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = nameof(GetCourseById))]
        public async Task<ActionResult<CourseReadDTO>> GetCourseById(int id)
        {
            var course = await _unitOfWork.CourseService
                .GetFirstOrDefault(
                    filter: c => c.CourseId == id,
                    includeProperties: "Department,CourseEnrollments,CourseAssignments"
                );

            if (course is null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<CourseReadDTO>(course);
            return Ok(objDto);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetAllCourses()
        {
            var courses = await _unitOfWork.CourseService
                .GetAll(includeProperties: "Department,CourseEnrollments,CourseAssignments");

            var objDto = new List<CourseReadDTO>();
            foreach (var course in courses)
            {
                objDto.Add(_mapper.Map<CourseReadDTO>(course));
            }

            return Ok(objDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutCourse(int id, [FromBody] CourseUpdateDTO courseDto)
        {
            if (courseDto is null)
            {
                return BadRequest();
            }

            var entity = _unitOfWork.CourseService.Get(id);
            if (entity is null)
            {
                return NotFound();
            }

            _mapper.Map(courseDto, entity);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(nameof(PutCourse), "unable to save changes");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpPatch("{id:int}", Name = "PatchCourseDto")]
        public async Task<ActionResult> PatchCourseDto(int? id, [FromBody] JsonPatchDocument<CourseUpdateDTO> patchEntity)
        {
            if (id is null || !ModelState.IsValid || patchEntity is null)
            {
                return BadRequest(ModelState);
            }

            // get entity to update
            var course = _unitOfWork.CourseService.Get(id.Value);
            if (course is null)
            {
                return NotFound();
            }

            // map that entity with defined DTO 
            var objDto = _mapper.Map<CourseUpdateDTO>(course);
            // apply HttpPatch
            patchEntity.ApplyTo(objDto, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // map the result back to entity
            // NOTE: without this mapping back. operation of HttpPatch will not be applied
            _mapper.Map(objDto, course);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "PatchCourse")]
        public async Task<IActionResult> PatchCourse(int? id, [FromBody] JsonPatchDocument<Course> patchDoc)
        {
            if (id is null || patchDoc is null)
            {
                return BadRequest(ModelState);
            }

            var course = _unitOfWork.CourseService.Get(id.Value);
            if (course is null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(course, ModelState);
            // var isValidModel = TryValidateModel(course);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = nameof(DeleteCourse))]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var courseToRemove = _unitOfWork.CourseService.Get(id);
            if (courseToRemove is null)
            {
                return BadRequest(ModelState);
            }

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
        public async Task<IActionResult> PostCourse([FromBody] CourseCreateDTO courseCreateDTO)
        {
            // NOTE: When add new course with the `custom ID as auto increment` 
            // DON'T add the ID. Just add all other properties WITHOUT ID. 
            // EF Core will automatically add the ID with advancing of 1 for you.

            // If you ignore preceding NOTE and insert ID field when adding new course
            // you will FAILED without specified error from the system! 
            if (courseCreateDTO is null)
            {
                return BadRequest(ModelState);
            }

            // mapper.Map<DestinationClass>(sourceObject);
            var objDto = _mapper.Map<Course>(courseCreateDTO);
            try
            {
                await _unitOfWork.CourseService.Create(objDto);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(PostCourse), ex.Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute(nameof(GetCourseById), new { id = objDto.CourseId }, objDto); // id must be matched with the `id` parameter in GetCourseById
        }
    }
}
