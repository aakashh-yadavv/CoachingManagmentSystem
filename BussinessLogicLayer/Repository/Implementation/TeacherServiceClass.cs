using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MngBussinessLogicLayer.DTO.Teacher;
using MngBussinessLogicLayer.Repository.Interface;
using MngDataAccessLayer.Data;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Implementation
{
    public class TeacherServiceClass : ITeacher
    {
        private readonly CoachingDbContext _coachingDbContext;
        private readonly IMapper _mapper;
        public TeacherServiceClass(CoachingDbContext coachingDbContext , IMapper mapper)
        {
            _coachingDbContext = coachingDbContext;
            _mapper = mapper;
        }
        public async Task<CreateTeacherDto> AddTeacher(CreateTeacherDto createTeacherDto)
        {
          var teacher = _mapper.Map<Teacher>(createTeacherDto);
            await _coachingDbContext.AddAsync(teacher);
            await _coachingDbContext.SaveChangesAsync();
            return createTeacherDto;
        }

        public async Task<string> DeleteTeacher(int id)
        {
          var batch = await _coachingDbContext.Batches.AnyAsync(m=>m.TeacherId==id);
            if (batch)
            {
                return "Cannot Delete Because Batches Are Exist";
            }
            var teacher = await _coachingDbContext.Teachers.FirstOrDefaultAsync(m=>m.Id==id);
            if(teacher == null)
            {
                throw new Exception("Id not found");
            }
            _coachingDbContext.Teachers.Remove(teacher);
            await _coachingDbContext.SaveChangesAsync();
            return "Delete Successfully";
        }

        public async Task<List<ResponseTeacherDto>> GetAllTeacher()
        {
        var show = await _coachingDbContext.Teachers.ToListAsync();

            return _mapper.Map<List<ResponseTeacherDto>>(show);
        }

        public Task<TeacherDto> GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateTeacherDto> UpdateTeacher(int id, UpdateTeacherDto updateTeacherDto)
        {
            throw new NotImplementedException();
        }
    }
}
