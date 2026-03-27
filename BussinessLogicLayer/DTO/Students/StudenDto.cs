using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Students
{
    public class StudenDto
    {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

            public string Address { get; set; }

            public DateTime DateOfBirth { get; set; }

            public int CourseId { get; set; }
            

            public int BatchId { get; set; }
          
        }
}
