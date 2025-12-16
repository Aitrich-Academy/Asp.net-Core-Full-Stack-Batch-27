using Microsoft.EntityFrameworkCore;

namespace HireMeNow.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Experience> Experiences { get; set; }

        public virtual DbSet<Interview> Interviews { get; set; }

        public virtual DbSet<Job> Jobs { get; set; }

        public virtual DbSet<Qualification> Qualifications { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
