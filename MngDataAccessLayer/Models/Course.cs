using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngDataAccessLayer.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string CourseName { get; set; } = "Full Stack Developer";

        public string Duration { get; set; }

        public decimal Fees { get; set; }

        public ICollection<Batch> Batches { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
