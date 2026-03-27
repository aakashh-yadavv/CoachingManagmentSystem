using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Teacher
{
    public class CreateTeacherDto
    {
       

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public decimal Salary { get; set; }
    }
}
