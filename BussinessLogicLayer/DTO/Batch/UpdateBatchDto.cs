using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.DTO.Batch
{
    public class UpdateBatchDto
    {
     

        public string BatchName { get; set; } = "Morning Batch";

     

    

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

      
    }
}
