using MngBussinessLogicLayer.DTO.Batch;
using MngBussinessLogicLayer.DTO.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Course
{
    public class ResponseCourseDto
    {
        public int Id { get; set; }

        public string CourseName { get; set; } = "Full Stack Developer";

        public string Duration { get; set; }

        public decimal Fees { get; set; }
        //public ICollection<BatchDto> Batches { get; set; }
        //public ICollection<StudenDto> Students { get; set; }
    }
}
