using MngBussinessLogicLayer.DTO.Course;
using MngBussinessLogicLayer.DTO.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface ITeacher
    {
        Task<List<ResponseTeacherDto>> GetAllTeacher();
        Task<TeacherDto> GetTeacherById(int id);
        Task<CreateTeacherDto> AddTeacher(CreateTeacherDto createTeacherDto);
        Task<UpdateTeacherDto> UpdateTeacher(int id, UpdateTeacherDto updateTeacherDto);
        Task<string> DeleteTeacher(int id);
    }
}
