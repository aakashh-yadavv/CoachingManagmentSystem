using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Fees
{
    public class CreateFeesDto
    {

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
    
        public DateTime PaymentDate { get; set; }

        public string? PaymentMode { get; set; }

       
    }
}
