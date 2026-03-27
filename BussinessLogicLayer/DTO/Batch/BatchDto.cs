using MngBussinessLogicLayer.DTO.Attendance;
using MngBussinessLogicLayer.DTO.Students;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Batch
{
    public class BatchDto
    {
        public int Id { get; set; }

        public string BatchName { get; set; } = "Morning Batch";

        public int CourseId { get; set; }
    

        public int TeacherId { get; set; }
     

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //public ICollection<StudenDto> Students { get; set; }

        //public ICollection<AttendaceDto> Attendances { get; set; }
    }
}
