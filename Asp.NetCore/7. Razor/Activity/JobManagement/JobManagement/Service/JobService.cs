using AutoMapper;
using JobManagement.Dto;
using JobManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Service
{
    public class JobService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public JobService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<JobDto>> GetAllJobsAsync()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return _mapper.Map<List<JobDto>>(jobs);
        }

        public async Task<JobDto> GetJobByIdAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            return _mapper.Map<JobDto>(job);
        }

        public async Task AddJobAsync(JobDto jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(int id, JobDto jobDto)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return;

            _mapper.Map(jobDto, job);
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
