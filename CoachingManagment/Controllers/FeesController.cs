using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.Fees;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly IFees _fees;
        public FeesController(IFees fees)
        {
            _fees = fees;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Addpayment([FromBody] CreateFeesDto createFeesDto, [FromQuery] int id)
        {
            if (createFeesDto == null)
            {
                return BadRequest("Request body is null");
            }
            var result = await _fees.AddFees(createFeesDto, id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet("GetFEesBYStudentId")]

        public async Task<IActionResult> getfees([FromQuery] int id)
        {
            var result = await _fees.GetFees(id);
            return Ok(result);
        }


        [Authorize(Roles = "Admin , User")]
        [HttpGet("coursefees")]
        public async Task<IActionResult> getcoursefees()
        {
            var result = await _fees.GetCourseFees();
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFees(int id)
        {
            var result = await _fees.DeleteFees(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet("GetRemainingFees")]
        public async Task<IActionResult> getremainingfees(int id)
        {
            var result = await _fees.GetRemainingFees(id);
            return Ok(result);
        }
    }
}