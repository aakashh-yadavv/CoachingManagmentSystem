using MngBussinessLogicLayer.DTO.Course;
using MngBussinessLogicLayer.DTO.Pagination;
using MngBussinessLogicLayer.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Interface
{
    public interface IStudents
    {
        Task<List<ResponseStudentsDto>> GetAllStudents(PaginationDto paginationDto);
        Task<StudenDto> GetStudentById(int id );
        Task<StudentsDetails> GetStudentsDetails(int id);
       
        Task<CreateStudentsDto> AddStudent(CreateStudentsDto createStudentsDto , int courseid , int bathcid);
     
        Task<string> DeleteStudent(int id);
        Task<List<StudentsshowDto>> GetStudentByCourseName(string coursename);
    }
}
