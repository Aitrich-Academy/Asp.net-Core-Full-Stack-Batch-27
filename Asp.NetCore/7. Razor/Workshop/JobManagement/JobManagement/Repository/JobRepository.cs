using AutoMapper;
using JobManagement.Dto;
using JobManagement.Interface;
using JobManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Repository
{
    public class JobRepository:IJobRepository
    {
        private readonly ApplicationDbContext _context;
       

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<List<Jobs>> GetAllJobsAsync()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Jobs> GetJobByIdAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            return job;
        }

        public async Task AddJobAsync(Jobs job)
        {
           
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(int id, Jobs job)
        {
            var existingJob = await _context.Jobs.FindAsync(id);
            if (existingJob == null) return; // Ensure job exists

            _context.Entry(existingJob).State = EntityState.Detached; // Detach old instance

            //var updatedJob = _mapper.Map<Jobs>(jobDto);
            var updatedJob = job;
            updatedJob.Id = id; // Ensure the ID remains the same
           
            _context.Jobs.Attach(updatedJob); // Attach the new instance
            _context.Entry(updatedJob).State = EntityState.Modified; // Mark as modified

            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
