using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MngBussinessLogicLayer.DTO.Batch;
using MngBussinessLogicLayer.Repository.Interface;

namespace CoachingManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatch _batchService;
        public BatchController(IBatch batchService)
        {
            _batchService = batchService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddBatch(CreateBatchDto createBatchDto , int courseid , int teacherid)
        {
            var result = await _batchService.AddBatch(createBatchDto ,courseid , teacherid);
            return Ok(result);
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetAllBatch")]

        public async Task<IActionResult> GetAllBatche()
        {
            var result = await _batchService.GetAllBatch();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]

        public async Task<IActionResult> DeleteBatch(int id)
        {
            var result = await _batchService.DeleteBatch(id);
            return Ok(result);
        }
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<IActionResult>  UpdateBatch(int id ,  UpdateBatchDto updateBatchDto)
        {
            var result = await _batchService.UpdateBatch(id ,updateBatchDto);
            return Ok(result);
        }
    }
}
