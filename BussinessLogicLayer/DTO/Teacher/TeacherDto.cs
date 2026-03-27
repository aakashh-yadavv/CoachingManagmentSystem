using MngBussinessLogicLayer.DTO.Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Teacher
{
    public class TeacherDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public decimal Salary { get; set; }
        public ICollection<BatchDto> Batches { get; set; }
    }
}
