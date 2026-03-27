using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MngBussinessLogicLayer.DTO.Attendance;
using MngBussinessLogicLayer.DTO.Batch;
using MngBussinessLogicLayer.DTO.Course;
using MngBussinessLogicLayer.DTO.Fees;
using MngBussinessLogicLayer.DTO.Students;
using MngBussinessLogicLayer.DTO.Teacher;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Mapper
{
    public  class ApplicationMapp :Profile
    {
        public ApplicationMapp()
        {

            //Course Mapping
            CreateMap<Course, CourseDto>().ReverseMap();
             CreateMap<CreateCourseDto, Course>().ReverseMap();
             CreateMap<UpdateCourseDto, Course>().ReverseMap();
             CreateMap<ResponseCourseDto, Course>().ReverseMap();

            //Batch Mapping

               CreateMap<Batch, BatchDto>().ReverseMap();
                CreateMap<CreateBatchDto, Batch>().ReverseMap();
                CreateMap<UpdateBatchDto, Batch>().ReverseMap();
                
            //Teacher Mapping
            CreateMap<Teacher, TeacherDto>().ReverseMap();
             CreateMap<CreateTeacherDto, Teacher>().ReverseMap();
             CreateMap<UpdateTeacherDto, Teacher>().ReverseMap();
            CreateMap<ResponseTeacherDto, Teacher>().ReverseMap();

            //student Mapping
            CreateMap<Student , StudenDto>().ReverseMap();
            CreateMap<CreateStudentsDto, Student>().ReverseMap();
       
             CreateMap<ResponseStudentsDto, Student>().ReverseMap();

            //Attendance Mapping
             CreateMap<Attendance, AttendaceDto>().ReverseMap();
             CreateMap<CreateAttendance, Attendance>().ReverseMap();
             

            //fees Mapping
             CreateMap<Fees, FeesDto>().ReverseMap();
             CreateMap<CreateFeesDto, Fees>().ReverseMap();
        }
    }
}
