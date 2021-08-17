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
using SchoolApiSrc.DTOs.LecturerDTO;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : ControllerBase
    {
        private readonly ILectureService _service;
        private readonly IMapper _mapper;
        public LecturerController(ILectureService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = nameof(GetLecturer))]
        public async Task<ActionResult<LecturerReadDTO>> GetLecturer(int? id)
        {
            if (id is null)
            {
                return BadRequest(ModelState);
            }

            var lecturer = await _service.GetLecturer(id.Value);
            if (lecturer is null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<LecturerReadDTO>(lecturer);

            if (lecturer.CourseAssignments != null)
            {
                foreach (var course in lecturer.CourseAssignments)
                {
                    Dictionary<string, string> dictCourse = new Dictionary<string, string>()
                    {
                        {"courseId" , course.CourseId.ToString()},
                        {"courseName" , course.Course.CourseName}
                    };

                    objDto.DictCourses.Add(dictCourse);
                }
            }
            return Ok(objDto);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturerReadDTO>>> GetAllLecturers()
        {
            var lecturers = await _service.GetAllLecturers();
            if (lecturers is null)
            {
                return NotFound();
            }

            var objDtos = new List<LecturerReadDTO>();

            foreach (var lecturer in lecturers)
            {
                objDtos.Add(_mapper.Map<LecturerReadDTO>(lecturer));
            }

            return Ok(objDtos);
        }


        [HttpPost]
        public async Task<IActionResult> CreateLecturer([FromBody] LecturerCreateDTO lecturerDTO)
        {
            if (lecturerDTO is null)
            {
                return BadRequest(ModelState);
            }

            var objDto = _mapper.Map<Lecturer>(lecturerDTO);
            await _service.CreateLecturer(objDto);
            await _service.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id:int}", Name = nameof(DeleteLecturer))]
        public async Task<IActionResult> DeleteLecturer(int? id)
        {
            if (id is null)
            {
                return BadRequest(ModelState);
            }

            var lecturerToDelete = await _service.GetLecturer(id.Value);
            if (lecturerToDelete is null)
            {
                return NotFound();
            }

            _service.DeleteLecturer(lecturerToDelete);
            await _service.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutLecturer(int id, [FromBody] LecturerUpdateDTO lecturerDTO)
        {
            if (lecturerDTO is null)
            {
                return BadRequest(ModelState);
            }

            var lecturerToUpdate = await _service.GetLecturer(id);
            if (lecturerToUpdate is null)
            {
                return NotFound();
            }

            _mapper.Map(lecturerDTO, lecturerToUpdate);
            await _service.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLecturer), new { id = lecturerToUpdate.Id }, lecturerToUpdate);
        }


        // NOTE: HttpPatch for DTO needs 2 times mapping
        [HttpPatch("{id:int}", Name = "PatchLecturerDto")]
        public async Task<ActionResult> PatchLecturerDto(int? id, [FromBody] JsonPatchDocument<LecturerUpdateDTO> patchEntity)
        {
            if (id is null || !ModelState.IsValid || patchEntity is null)
            {
                return BadRequest(ModelState);
            }

            var lecturerToUpdate = await _service.GetLecturer(id.Value);
            if (lecturerToUpdate is null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<LecturerUpdateDTO>(lecturerToUpdate);
            patchEntity.ApplyTo(objDto, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(objDto, lecturerToUpdate);
            await _service.SaveChangesAsync();
            return NoContent();
        }
    }
}