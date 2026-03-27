using MngBussinessLogicLayer.DTO.Course;
using MngBussinessLogicLayer.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface ICourse
    {
        Task<List<ResponseCourseDto>> GetAllCourse();
        Task<List<CoursePerStudent>> GetCoursePerStudents();
        Task<CreateCourseDto> AddCuorse(CreateCourseDto createCourseDto);
        Task<string> UpdateCourse(int id, UpdateCourseDto updateCourseDto);
        Task<string> DeleteCourse(int id);
    }
}
