using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MngBussinessLogicLayer.DTO.Attendance;
using MngBussinessLogicLayer.DTO.Pagination;
using MngBussinessLogicLayer.Repository.Interface;
using MngDataAccessLayer.Data;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Implementation
{
    public class AttendanceServiceClass : IAttendance
    {
        private readonly CoachingDbContext _coachingdbContext;
        private readonly IMapper _mapper; 
        public AttendanceServiceClass(CoachingDbContext coachingDbContext , IMapper mapper)
        {
           _coachingdbContext = coachingDbContext;
            _mapper = mapper;
        }

        public async Task<CreateAttendance> AddAttendance(CreateAttendance createattendace, int batchid, int studentid)
        {
            var attendace = _mapper.Map<Attendance>(createattendace);
            var creatAttendance = await _coachingdbContext.Batches.FirstOrDefaultAsync(m=>m.Id == batchid);
            if(creatAttendance == null)
            {
                throw new Exception("Batch not found");
            }
            attendace.BatchId= batchid;
            var creatAttendance1 = await _coachingdbContext.Students.FirstOrDefaultAsync(m => m.Id == studentid);
            if(creatAttendance1 == null)
            {
                throw new Exception("Student Not found");
            }
            attendace.StudentId= studentid;
             await _coachingdbContext.AddAsync(attendace);
            await _coachingdbContext.SaveChangesAsync();
            return createattendace;
        }

        public async Task<List<AttendaceDto>> GetAllAttendance(PaginationDto paginationDto)
        {
            var show = await _coachingdbContext.Attendances.Skip((paginationDto.PageNumber-1)*paginationDto.PageSize)
                .Take(paginationDto.PageSize)  .ToListAsync();
            return _mapper.Map<List<AttendaceDto>>(show);
        }

        public async Task<List<AttendaceDto>> GetAttendance(int studentid, PaginationDto paginationDto)
        {
            var data = await _coachingdbContext.Attendances .Skip((paginationDto.PageNumber-1)*paginationDto.PageSize)
                .Take(paginationDto.PageSize).Where(m=>m.StudentId == studentid).ToListAsync();

            if (data == null)
            {
                throw new Exception("Student ID Is not available");
            }
            return _mapper.Map<List<AttendaceDto>>(data);
        }

        public Task<AttendaceDto> UpdateAttendance(int id, AttendaceDto attendaceDto )
        {
            throw new NotImplementedException();
        }

       
    }

}