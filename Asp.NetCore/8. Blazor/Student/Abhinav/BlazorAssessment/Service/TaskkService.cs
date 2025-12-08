using AutoMapper;
using BlazorAssessment.Dto;
using BlazorAssessment.Interface;
using BlazorAssessment.Models;

namespace BlazorAssessment.Service
{
    public class TaskkService : ITaskkService
    {
        private readonly ITaskkRepository _repository;
        private readonly IMapper _mapper;

        public TaskkService(ITaskkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TaskkDto>> GetAllTaskAsync()
        {
            var task = await _repository.GetAllTaskAsync();
            return _mapper.Map<List<TaskkDto>>(task);
        }

        public async Task<TaskkDto> GetTaskByIdAsync(int id)
        {
            var task = await _repository.GetTaskByIdAsync(id);
            return _mapper.Map<TaskkDto>(task);
        }
        public async Task AddTaskAsync(TaskkDto taskkDto)
        {
            var task=_mapper.Map<Taskk>(taskkDto);
           await _repository.AddTaskAsync(task);
      
        }
        public async Task DeleteTaskAsync(int id)
        {  
            await _repository.DeleteTaskAsync(id);
        }
    }
}
