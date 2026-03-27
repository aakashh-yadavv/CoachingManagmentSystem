using MngBussinessLogicLayer.DTO.Attendance;
using MngBussinessLogicLayer.DTO.Pagination;
using MngBussinessLogicLayer.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface IAttendance
    {
        
        Task<List<AttendaceDto>> GetAttendance(int studentid , PaginationDto paginationDto);
        Task<List<AttendaceDto>> GetAllAttendance(PaginationDto paginationDto);
        Task<CreateAttendance> AddAttendance(CreateAttendance createattendace, int batchid , int studentid);
        Task<AttendaceDto> UpdateAttendance(int id, AttendaceDto attendaceDto);
        
    }
}
