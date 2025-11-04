using JobManagement.Dto;
using JobManagement.Model;
namespace JobManagement.Interface
{
    public interface IJobRepository
    {
        public Task<List<Jobs>> GetAllJobsAsync();

        public Task<Jobs> GetJobByIdAsync(int id);


        public Task AddJobAsync(Jobs job);


        public Task UpdateJobAsync(int id, Jobs job);

        public Task DeleteJobAsync(int id);
    }
}
