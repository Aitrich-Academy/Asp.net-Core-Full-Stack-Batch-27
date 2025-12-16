using BlazorAssessment.Interface;
using BlazorAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAssessment.Repository
{
    public class TaskkRepository:ITaskkRepository
    {
        private readonly AppDbContext _context;

        public TaskkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Taskk>> GetAllTaskAsync()
        {
            var task = await _context.Tasks.ToListAsync();
            return task;
        }

        public async Task<Taskk> GetTaskByIdAsync(int id)
        {
            var task=await _context.Tasks.FindAsync(id);
            return task;
        }

        public async Task AddTaskAsync(Taskk taskk)
        {
            _context.Tasks.Add(taskk);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }

        }
    }
}
