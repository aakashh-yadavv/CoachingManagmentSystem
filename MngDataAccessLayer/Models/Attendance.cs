using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngDataAccessLayer.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        public string Status { get; set; }

        public DateTime AttendanceDate { get; set; }
      
    }
}
