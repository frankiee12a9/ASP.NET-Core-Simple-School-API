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
using SchoolApiSrc.DTOs.StudentDTO;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = nameof(GetStudent))]
        public async Task<ActionResult<StudentReadDTO>> GetStudent(int? id)
        {
            if (id is null)
            {
                return BadRequest(ModelState);
            }

            var student = await _unitOfWork.StudentService
                .GetFirstOrDefault(
                    filter: s => s.Id == id.Value,
                    includeProperties: "CourseEnrollments"
                );

            if (student is null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<StudentReadDTO>(student);
            return Ok(objDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> GetAllStudents()
        {
            var students = await _unitOfWork.StudentService.GetAll(
                includeProperties: "CourseEnrollments"
            );

            var objDtos = new List<StudentReadDTO>();
            foreach (var student in students)
            {
                objDtos.Add(_mapper.Map<StudentReadDTO>(student));
            }

            return Ok(objDtos);
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent(int id, [FromBody] StudentCreateDTO studentCreateDTO)
        {
            if (id != studentCreateDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var objDto = _mapper.Map<Student>(studentCreateDTO);
            try
            {
                await _unitOfWork.StudentService.Create(objDto);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError(nameof(CreateStudent), "Unable to save change");
                return BadRequest(ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{id:int}", Name = nameof(DeleteStudent))]
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if (id is null)
            {
                return BadRequest(ModelState);
            }

            var studentToDelete = _unitOfWork.StudentService.Get(id.Value);
            if (studentToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.StudentService.Remove(studentToDelete);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id:int}", Name = nameof(PutStudent))]
        public async Task<ActionResult> PutStudent(int id, [FromBody] StudentUpdateDTO studentDto)
        {
            if (id != studentDto.Id || studentDto is null)
            {
                return BadRequest(ModelState);
            }

            var studentToUpdate = _unitOfWork.StudentService.Get(id);
            if (studentToUpdate is null)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(studentDto, studentToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = studentDto.Id }, studentDto);
        }


        [HttpPatch("{id:int}", Name = "PatchStudentDto")]
        public async Task<ActionResult> PatchStudentDto(int? id, [FromBody] JsonPatchDocument<StudentUpdateDTO> patchEntity)
        {
            if (id is null || !ModelState.IsValid || patchEntity is null)
            {
                return BadRequest(ModelState);
            }

            var studentToUpdate = _unitOfWork.StudentService.Get(id.Value);
            if (studentToUpdate is null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<StudentUpdateDTO>(studentToUpdate);
            patchEntity.ApplyTo(objDto, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(objDto, studentToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}