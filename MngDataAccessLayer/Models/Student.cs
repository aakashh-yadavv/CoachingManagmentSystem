using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngDataAccessLayer.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        public ICollection<Fees> Fees { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
