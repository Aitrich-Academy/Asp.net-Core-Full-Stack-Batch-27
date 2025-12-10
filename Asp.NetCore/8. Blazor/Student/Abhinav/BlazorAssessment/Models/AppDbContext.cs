using Microsoft.EntityFrameworkCore;

namespace BlazorAssessment.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Taskk>  Tasks { get; set; }

    }
}
