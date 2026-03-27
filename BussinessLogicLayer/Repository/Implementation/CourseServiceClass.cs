using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MngBussinessLogicLayer.DTO.Course;
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
    public class CourseServiceClass : ICourse
    {
        private readonly CoachingDbContext _coachingDbContext;
        private readonly IMapper _mapper;
        public CourseServiceClass(CoachingDbContext coachingDbContext, IMapper mapper)
        {
            _coachingDbContext = coachingDbContext;
            _mapper = mapper;
        }
        public async Task<CreateCourseDto> AddCuorse(CreateCourseDto createCourseDto)
        {
            var course = _mapper.Map<Course>(createCourseDto);
            await _coachingDbContext.Courses.AddAsync(course);
            await _coachingDbContext.SaveChangesAsync();
            return  createCourseDto;

        }

        public async Task<string> DeleteCourse(int id)
        {
          var studentexit = await _coachingDbContext.Students.AnyAsync(m=>m.CourseId == id);
            if(studentexit)
            {
                return "Can Not delete becouse student exist";
            }
            var course = await _coachingDbContext.Courses.FirstOrDefaultAsync(m => m.Id == id);
            if(course == null)
            {
                return "Course Not Found";
            }
             
            _coachingDbContext.Courses.Remove(course);
            await _coachingDbContext.SaveChangesAsync();
            return "Course Deleted Successfully";
        }

        public async Task<List<ResponseCourseDto>> GetAllCourse()
        {
            var course = await _coachingDbContext.Courses
                .ToListAsync();
            return _mapper.Map<List<ResponseCourseDto>>(course);
        }

        public async Task<List<CoursePerStudent>> GetCoursePerStudents()
        {
           var course = await _coachingDbContext.Students.GroupBy(m => m.Course.CourseName)
                .Select(m => new CoursePerStudent
                {
                    CourseName = m.Key,
                    TotalStudent = m.Count()
                }).ToListAsync();
            
            return course;
        }

        public async Task<string> UpdateCourse(int id, UpdateCourseDto updateCourseDto)
        {
           var update = await _coachingDbContext.Courses.FirstOrDefaultAsync(m=>m.Id == id);
            if(update == null)
            {
                throw new Exception("Id not found");
            }
            update.Duration = updateCourseDto.Duration;
            update.Fees = updateCourseDto.Fees;
            _coachingDbContext.Courses.Update(update);
            await _coachingDbContext.SaveChangesAsync();
            return "Update Succcessfull";
        }
    }
}
