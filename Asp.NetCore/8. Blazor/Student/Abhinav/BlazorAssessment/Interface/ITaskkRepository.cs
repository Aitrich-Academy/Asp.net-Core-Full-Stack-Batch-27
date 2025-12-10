using BlazorAssessment.Models;

namespace BlazorAssessment.Interface
{
    public interface ITaskkRepository
    {
        Task<List<Taskk>> GetAllTaskAsync();
        Task<Taskk> GetTaskByIdAsync(int id);
        Task AddTaskAsync(Taskk taskk);
        Task DeleteTaskAsync(int id);
    }
}
