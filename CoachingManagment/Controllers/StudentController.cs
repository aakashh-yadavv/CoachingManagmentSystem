using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.Pagination;
using MngBussinessLogicLayer.DTO.Students;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudents _studentService;
        public StudentController(IStudents students)
        {
            _studentService = students;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]

        public async Task<IActionResult> AddStudents(CreateStudentsDto createStudentsDto, int courseid, int batchid)
        {
            var result = await _studentService.AddStudent(createStudentsDto, courseid, batchid);
            return Ok(result);
        }



        [Authorize(Roles = "Admin , User")]
        [HttpGet("GetAllStudents")]

        public async Task<IActionResult> GetAction([FromQuery] PaginationDto paginationDto)
        {
            var result = await _studentService.GetAllStudents(paginationDto);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            return Ok(result);
        }


        [Authorize(Roles = "Admnin , User")]
        [HttpGet("GetStudentByCourseName")]

        public async Task<IActionResult> GetStudentByCourseName(string name)
        {
            var result = await _studentService.GetStudentByCourseName(name);
            return Ok(result);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet("Get Student By Id")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _studentService.GetStudentById(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet("Get Student Details")]

        public async Task<IActionResult> GetStudentDetails(int id)
        {
            var result = await _studentService.GetStudentsDetails(id);
            return Ok(result);
        }
    }
}