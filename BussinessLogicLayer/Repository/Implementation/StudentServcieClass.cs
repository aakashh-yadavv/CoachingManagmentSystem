using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using MngBussinessLogicLayer.DTO.Course;
using MngBussinessLogicLayer.DTO.Pagination;
using MngBussinessLogicLayer.DTO.Students;
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
    public class StudentServcieClass : IStudents
    {
        private readonly CoachingDbContext _coachingDbContext;
        private readonly IMapper _mapper;
        public StudentServcieClass(CoachingDbContext coachingDbContext , IMapper mapper)
        {
            _coachingDbContext = coachingDbContext;
            _mapper = mapper;
        }
        public async Task<CreateStudentsDto> AddStudent(CreateStudentsDto createStudentsDto , int courseid , int batchid)
        {
            var student = _mapper.Map<Student>(createStudentsDto);

            var addstd = await _coachingDbContext.Courses.FirstOrDefaultAsync(m=>m.Id == courseid);
            if(addstd == null)
            {
                return null;
            }
            student.CourseId = courseid;

            var addstd1 = await _coachingDbContext.Batches.FirstOrDefaultAsync(m => m.Id == batchid);
            if(addstd1 == null)
            {
                return null;
            }
            student.BatchId = batchid;

            await _coachingDbContext.Students.AddAsync(student);
            await _coachingDbContext.SaveChangesAsync();

            return createStudentsDto;
        }

        public async Task<string> DeleteStudent(int id)
        {
           var student = await _coachingDbContext.Students.FirstOrDefaultAsync(m => m.Id == id);
            if(student == null)
            {
                return "Student Not Found ";
            }
            _coachingDbContext.Students.Remove(student);
            _coachingDbContext.SaveChanges();
            return "Student delete successfully";
        }

        public async Task<List<ResponseStudentsDto>> GetAllStudents(PaginationDto paginationDto)
        {
            var show = await _coachingDbContext.Students .Skip((paginationDto.PageNumber-1)*paginationDto.PageSize)
                .Take(paginationDto.PageSize) .ToListAsync();
            return _mapper.Map<List<ResponseStudentsDto>>(show);
        }

        //public async Task<List<CoursePerStudent>> GetCoursePerStudents()
        //{
            
        //    var list = await _coachingDbContext.Students
        //        .GroupBy(m => m.Course.CourseName)
        //         .Select(a => new CoursePerStudent
        //         {
        //             CourseName = a.Key,
        //             TotalStudent = a.Count()
        //         }).ToListAsync();
        //    return list;
        //}

        public async Task<List<StudentsshowDto>> GetStudentByCourseName(string coursename)
        {
         var show = await _coachingDbContext.Students.Where(m => m.Course.CourseName.ToLower() == coursename.ToLower())
                .Select(m => new StudentsshowDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    //Email = m.Email,
                    //Phone = m.Phone,
                    //Address = m.Address,
                    //DateOfBirth = m.DateOfBirth,
                    CourseId = m.CourseId,
                    BatchId = m.BatchId
                }).ToListAsync();
            return show;
        }

        public async Task<StudenDto> GetStudentById(int id)
        {
            var student = await _coachingDbContext.Students.FirstOrDefaultAsync(m => m.Id == id);
            if(student == null)
            {
                return null;
            }
            return _mapper.Map<StudenDto>(student);


        }

        public async Task<StudentsDetails> GetStudentsDetails(int id)
        {
            var result = await _coachingDbContext.Students.Where(m => m.Id == id)
                .Include(m => m.Course).Include(m => m.Fees)
               .Select(m => new StudentsDetails
               {
                   Name = m.Name,
                   Address = m.Address,
                   CourseName = m.Course.CourseName,
                   TotalAmount = m.Fees.Select(a => a.TotalAmount).FirstOrDefault(),
                   PaidAmount = m.Fees.Sum(a => a.PaidAmount),
                 
               }).FirstOrDefaultAsync();
            if(result == null)
            {
                return null;
            }

            return new StudentsDetails
            {
                Name = result.Name,
                CourseName = result.CourseName,
                TotalAmount = result.TotalAmount,
                PaidAmount = result.PaidAmount,
                RemainingAmount = result.TotalAmount - result.PaidAmount
            };



        }
    }
}
