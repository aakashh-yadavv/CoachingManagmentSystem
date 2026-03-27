using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.Course;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseService;
        public CourseController(ICourse courseService)
        {
            _courseService = courseService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCourse(CreateCourseDto createCourseDto)
        {
            var course = await _courseService.AddCuorse(createCourseDto);
            return Ok(course);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetAllCourses")]

        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await _courseService.GetAllCourse();
            return Ok(courses);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourse(id);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto updateCourseDto)
        {
            var result = await _courseService.UpdateCourse(id,updateCourseDto);
            return Ok(result);
        }

        [Authorize(Roles ="Admin , User")]
        [HttpGet("Count Stundet")]

        public async Task<IActionResult> GetCountStudents()
        {
            var result = await _courseService.GetCoursePerStudents();
            return Ok (result);
        }
    }
}
