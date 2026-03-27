using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngDataAccessLayer.Models
{
    public class Batch
    {
        public int Id { get; set; }

        public string BatchName { get; set; } = "Morning Batch";

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public DateTime StartDate { get; set; } 

        public DateTime EndDate { get; set; } 

        public ICollection<Student> Students { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
