using BlazorAssessment.Dto;
using BlazorAssessment.Models;

namespace BlazorAssessment.Interface
{
    public interface ITaskkService
    {
        Task<List<TaskkDto>> GetAllTaskAsync();
        Task<TaskkDto> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskkDto taskkDto);
        Task DeleteTaskAsync(int id);
    }
}
