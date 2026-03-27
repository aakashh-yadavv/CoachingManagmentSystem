using MngBussinessLogicLayer.DTO.Attendance;
using MngBussinessLogicLayer.DTO.Fees;
using MngBussinessLogicLayer.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface IFees
    {
        Task<List<FeesDto>> GetFees(int id);
        Task<string> AddFees(CreateFeesDto createFeesDto, int id );
        Task<decimal> GetRemainingFees(int id);
        Task<List<CourseFeesDto>> GetCourseFees();
        Task<string> DeleteFees(int id);
 

    }
}
