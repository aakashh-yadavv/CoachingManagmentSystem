using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngDataAccessLayer.Models
{
    public class Fees
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? RemainingAmount { get; set; }

        public DateTime PaymentDate { get; set; } 

        public string? PaymentMode { get; set; }

        public string? Status { get; set; }
    }
}
