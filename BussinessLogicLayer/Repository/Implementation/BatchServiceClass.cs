using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MngBussinessLogicLayer.DTO.Batch;
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
    public class BatchServiceClass : IBatch
    {
        private readonly CoachingDbContext _coachingDbContext;
        private readonly IMapper _mapper;
        public BatchServiceClass(CoachingDbContext coachingDbContext, IMapper mapper)
        {
            _coachingDbContext = coachingDbContext;
            _mapper = mapper;
        }
        public async Task<CreateBatchDto> AddBatch(CreateBatchDto createBatchDto ,int courseid , int Teacherid)
        {
           var batch = _mapper.Map<Batch>(createBatchDto);
          var  batch2 = await _coachingDbContext.Courses.FirstOrDefaultAsync(m => m.Id == courseid);
          
            if (batch == null)
            {
                return null;
            }
            batch.CourseId = courseid;
            var batch3 = await _coachingDbContext.Teachers.FirstOrDefaultAsync(a => a.Id == Teacherid);
            if(batch3 == null)
            {
                return null;
            }
            batch.TeacherId = Teacherid;
            await _coachingDbContext.AddAsync(batch);
            await _coachingDbContext.SaveChangesAsync();

            return createBatchDto;
        }

        public async Task<string> DeleteBatch(int id)
        {
            var Studentexit = await _coachingDbContext.Students.AnyAsync(m=> m.BatchId == id);
            if (Studentexit)
            {
                return "Course Cannot delete because student exist";
            }
            var batch = await _coachingDbContext.Batches.FirstOrDefaultAsync(m => m.Id == id);
            if (batch == null)
            {
                return "Batch Not Found";
            }

            _coachingDbContext.Batches.Remove(batch);
            await _coachingDbContext.SaveChangesAsync();
            return "Batch Deleted Successfully";

        }

        public async Task<List<BatchDto>> GetAllBatch()
        {
            var show = await _coachingDbContext.Batches.Include(m => m.Course).Include(m => m.Teacher).ToArrayAsync();
            return _mapper.Map<List<BatchDto>>(show);
        }

        public Task<BatchDto> GetBatchById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateBatch(int id, UpdateBatchDto updateBatchDto)

        {
          
               var update = await _coachingDbContext.Batches.FirstOrDefaultAsync(m=>m.Id == id);
            if(update == null)
            {
                throw new Exception("ID Not Match");
            }

           update.BatchName = updateBatchDto.BatchName;
            update.StartDate = updateBatchDto.StartDate;
            update.EndDate = updateBatchDto.EndDate;
            _coachingDbContext.Batches.Update(update);
            await _coachingDbContext.SaveChangesAsync();

            return "Update successfull";
        }
    }
}
