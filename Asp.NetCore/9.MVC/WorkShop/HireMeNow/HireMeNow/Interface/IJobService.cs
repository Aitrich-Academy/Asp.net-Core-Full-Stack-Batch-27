using HireMeNow.Models;

namespace HireMeNow.Interface
{
    public interface IJobService
    {
        public List<Job> GetJobs();

        public List<Job> GetJobPosted(Guid cmpid);
    }
}
