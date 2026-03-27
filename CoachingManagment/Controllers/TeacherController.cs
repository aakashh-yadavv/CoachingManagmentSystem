using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.Teacher;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherService;
        public TeacherController(ITeacher teacher)
        {
            _teacherService = teacher;
        }

       [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> AddTeacher(CreateTeacherDto createTeacherDto)
        {
            var result = await _teacherService.AddTeacher(createTeacherDto);
            return Ok(result);
        }


        [Authorize(Roles = "Admin , User")]
        [HttpGet("GetAllTeacher")]

        public async Task<IActionResult> GetAllTeacher()
        {
            var result = await _teacherService.GetAllTeacher();
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeleteTeacher(id);
            return Ok(result);
        }

    }
}
