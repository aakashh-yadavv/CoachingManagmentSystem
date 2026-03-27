using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Course
{
    public class CreateCourseDto
    {
   

        public string CourseName { get; set; } = "Full Stack Developer";

        public string Duration { get; set; }

        public decimal Fees { get; set; }
    }
}
