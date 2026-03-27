using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Attendance
{
    public class CreateAttendance
    {
        public string Status { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
