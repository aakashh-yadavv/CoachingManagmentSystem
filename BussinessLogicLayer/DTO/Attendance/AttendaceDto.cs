using Microsoft.VisualBasic;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Attendance
{
    public class AttendaceDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
   

        public int BatchId { get; set; }
   

        public string Status { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
