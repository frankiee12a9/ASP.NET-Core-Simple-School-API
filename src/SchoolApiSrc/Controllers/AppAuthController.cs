using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolApiSrc.DTOs.AppAuthDTO;
using SchoolApiSrc.Models;
using SchoolApiSrc.Services.IServices;

namespace SchoolApiSrc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppAuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;
        public AppAuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAppAuthInfoDTO>>> GetAllUsers()
        {
            var appUserAuths = await _service.GetAll();
            if (appUserAuths is null)
            {
                return NotFound(ModelState);
            }

            var objDtos = new List<UserAppAuthInfoDTO>();
            foreach (var appUserAuth in appUserAuths)
            {
                objDtos.Add(_mapper.Map<UserAppAuthInfoDTO>(appUserAuth));
            }

            return Ok(objDtos);
        }


        [HttpPost("", Name = nameof(Register))]
        public async Task<ActionResult> Register(AppRegisterDTO registerDTO)
        {
            if (await _service.IsAccountExists(registerDTO.Username) || registerDTO is null)
            {
                return BadRequest(ModelState);
            }

            var objDto = _mapper.Map<AppLoginInfo>(registerDTO);
            await _service.Register(objDto);
            await _service.SaveAsync();
            return Ok(objDto);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AppLoginDTO loginDTO)
        {
            if (loginDTO is null || !await _service.IsAccountExists(loginDTO.Username))
            {
                return BadRequest(ModelState);
            }

            var account = await _service.GetOne(loginDTO.Username);
            if (account is null)
            {
                return NotFound(ModelState);
            }

            var objDto = _mapper.Map<AppLoginDTO>(account);
            var loginStatus = await _service.Login(objDto.Username, objDto.Password);

            if (!loginStatus)
            {
                return NotFound(ModelState);
            }
            // return Ok(objDto.JwtKey);
            return Ok(account.JwtKey);
        }

        // [HttpDelete, Route("api/appauth/deleteuser/{userName}")]
        [HttpDelete("{id:int}", Name = nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id is null)
            {
                return BadRequest(ModelState);
            }

            _service.Delete(id.Value);
            await _service.SaveAsync();
            return NoContent();
        }
    }

}