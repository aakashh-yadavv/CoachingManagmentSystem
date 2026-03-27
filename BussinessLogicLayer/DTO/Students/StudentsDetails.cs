using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Students
{
    public class StudentsDetails
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CourseName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? RemainingAmount { get; set; }

    }
}
