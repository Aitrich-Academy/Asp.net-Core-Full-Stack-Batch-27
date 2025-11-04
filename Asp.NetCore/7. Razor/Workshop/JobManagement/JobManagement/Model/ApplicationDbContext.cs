using Microsoft.EntityFrameworkCore;

namespace JobManagement.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Jobs> Jobs { get; set; }
    }
}
