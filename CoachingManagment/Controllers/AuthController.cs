using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.JWT;
using MngBussinessLogicLayer.Repository.Implementation;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;
        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);

            return Ok(new { Message = result });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDtos loginDto)
        {
            var result = await _authService.Login(loginDto);

            return Ok(new { Token = result });
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.AdminRegister(registerDto);
            return Ok(new { Message = result });
        }
    }
}
