using Microsoft.EntityFrameworkCore;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngDataAccessLayer.Data
{
    public class CoachingDbContext : DbContext
    {
        public CoachingDbContext(DbContextOptions<CoachingDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Course>()
                .Property(c => c.Fees)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Fees>()
                .Property(f => f.TotalAmount)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Fees>()
              .Property(f => f.PaidAmount)
              .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Fees>()
              .Property(f => f.RemainingAmount)
              .HasColumnType("decimal(18,2)");

            // Student → Course
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Student → Batch
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Batch)
                .WithMany(b => b.Students)
                .HasForeignKey(s => s.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Attendance → Student
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Attendance → Batch
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Batch)
                .WithMany(b => b.Attendances)
                .HasForeignKey(a => a.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }
    }

}