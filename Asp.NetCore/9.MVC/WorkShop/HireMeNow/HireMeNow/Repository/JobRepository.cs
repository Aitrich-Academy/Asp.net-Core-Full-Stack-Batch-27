using HireMeNow.Interface;
using HireMeNow.Models;
using Microsoft.EntityFrameworkCore;

namespace HireMeNow.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Job job)
        {
            _context.Jobs.AddAsync(job);

            _context.SaveChanges();

            return true;
        }

        public List<Job> GetJobPosted(Guid cmpid)
        {
            return _context.Jobs.Where(e => e.CompanyId == cmpid).Include(e => e.Company).ToList();
        }

        public List<Job> GetJobs()
        {
            return _context.Jobs.Include(e => e.Company).ToList();
        }
    }
}
