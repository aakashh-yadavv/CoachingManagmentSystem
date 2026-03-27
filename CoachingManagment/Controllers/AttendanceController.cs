using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.Attendance;
using MngBussinessLogicLayer.DTO.Pagination;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendance _attendanceService;
        public AttendanceController(IAttendance attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAttendance(CreateAttendance createattendance, int batchid, int studentid)
        {
            var result = await _attendanceService.AddAttendance(createattendance, batchid, studentid);
            return Ok(result);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet("GetBystudentid")]
        public async Task<IActionResult> GetAllAttendance(int studentid,[FromQuery]PaginationDto paginationDto)
        {
            var result = await _attendanceService.GetAttendance(studentid,paginationDto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet]
        public async Task<IActionResult> GetAttendance([FromQuery]PaginationDto paginationDto)
        {
            var result = await _attendanceService.GetAllAttendance(paginationDto);
            return Ok (result);
        }
    }
}
