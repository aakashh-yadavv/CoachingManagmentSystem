using MngBussinessLogicLayer.DTO.Batch;
using MngBussinessLogicLayer.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface IBatch
    {
        Task<List<BatchDto>> GetAllBatch();
        Task<BatchDto> GetBatchById(int id);
        Task<CreateBatchDto> AddBatch(CreateBatchDto createBatchDto , int courseid, int Teacherid);
        Task<string> UpdateBatch(int id, UpdateBatchDto updateBatchDto);
        Task<string> DeleteBatch(int id);
    }
}
