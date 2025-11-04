using JobManagement.Dto;
using JobManagement.Model;
using JobManagement.Repository;

namespace JobManagement.Interface
{
    public interface IJobService
    {
        public Task<List<JobDto>> GetAllJobsAsync();

        public Task<JobDto> GetJobByIdAsync(int id);


        public Task AddJobAsync(JobDto jobDto);


        public Task UpdateJobAsync(int id, JobDto jobDto);

        public Task DeleteJobAsync(int id);
       
    }
}
