using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MngBussinessLogicLayer.DTO.Fees;
using MngBussinessLogicLayer.Repository.Interface;
using MngDataAccessLayer.Data;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngBussinessLogicLayer.Repository.Implementation
{
    public class FeesServiceClass : IFees
    {
        private readonly CoachingDbContext _coachingDbContext;
        private readonly IMapper _mapper;
        public FeesServiceClass(CoachingDbContext coachingDbContext, IMapper mapper)
        {
            _coachingDbContext = coachingDbContext;
            _mapper = mapper;
        }
        public async Task<string> AddFees(CreateFeesDto createFeesDto, int id)
        {
            var student = await _coachingDbContext.Students.AnyAsync(m => m.Id == id);
            if (!student)
            {
                throw new Exception("Student not found");
            }

            // 👉 Total paid till now
            var totalPaid = await _coachingDbContext.Fees
                .Where(f => f.StudentId == id)
                .SumAsync(f => (decimal?)f.PaidAmount) ?? 0;

            // 👉 Total fees (assume same for all entries OR pass once)
            var totalFees = createFeesDto.TotalAmount;

            if (totalPaid >= totalFees)
            {
                throw new Exception("Fees already fully paid");
            }

            if (totalPaid + createFeesDto.PaidAmount > totalFees)
            {
                throw new Exception("Amount exceeds total fees");
            }

            var newPaidTotal = totalPaid + createFeesDto.PaidAmount;

            var feesadd = new Fees
            {
                StudentId = id,
                TotalAmount = totalFees,
                PaidAmount = createFeesDto.PaidAmount,
                RemainingAmount = totalFees - newPaidTotal,
                PaymentDate = DateTime.Now,
                PaymentMode = createFeesDto.PaymentMode,
                Status = newPaidTotal == 0 ? "Pending"
                        : newPaidTotal < totalFees ? "Partial"
                        : "Paid"
            };

            await _coachingDbContext.Fees.AddAsync(feesadd);
            await _coachingDbContext.SaveChangesAsync();

            return "Payment Successful";
        }


        public async Task<string> DeleteFees(int id )
        {
            var result = await _coachingDbContext.Fees.FirstOrDefaultAsync(m=>m.Id == id);
            if(result== null)
            {
                throw new Exception("Id not found");
            }
            _coachingDbContext.Fees.Remove(result);
            _coachingDbContext.SaveChanges();
            return "Delete successfully";

        }

        public async Task<List<CourseFeesDto>> GetCourseFees()
        {
            var data = await _coachingDbContext.Fees.Include(m=>m.Student).ThenInclude(a=>a.Course)
                .GroupBy(m => m.Student.Course.CourseName).Select(m => new CourseFeesDto
                {
                    CourseName = m.Key,
                    FeesAmount = m.Sum(a=>a.PaidAmount)
                }).ToListAsync();
            return data;
        }

        public async Task<List<FeesDto>> GetFees(int id)
        {
            var studentExists = await _coachingDbContext.Students.AnyAsync(m => m.Id == id);
            if (!studentExists)
            {
                throw new Exception("Studentid is not matched");
            }

            var fees = await _coachingDbContext.Fees.Where(m => m.StudentId == id).ToListAsync();
            if (fees == null|| fees.Count==0)
            {
                throw new Exception("No fees found  for this student");
            }
            return _mapper.Map<List<FeesDto>>(fees);

        }

        public async Task<decimal> GetRemainingFees(int id)
        {
           var student = await _coachingDbContext.Students.AnyAsync(m => m.Id == id);
            if (!student)
            {
                throw new Exception("Studentid is not matched");
            }
            var remainingFees = await _coachingDbContext.Fees.Where(m => m.StudentId == id)
              .OrderByDescending(m => m.PaymentDate).FirstOrDefaultAsync();
            if(remainingFees == null)
            {
                throw new Exception("No fees found record for this student ");
            }
            return (decimal)remainingFees.RemainingAmount;

        }
    }
}
