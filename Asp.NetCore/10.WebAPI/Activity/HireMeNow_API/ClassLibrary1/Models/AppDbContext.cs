using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<SignupRequest> SignUpRequests { get; set; }

        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
        public DbSet<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<WorkExperience> workExperiences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemUser>().ToTable("SystemUsers");
            modelBuilder.Entity<AuthUser>().ToTable("AuthUsers"); 

            base.OnModelCreating(modelBuilder);
        }


    }
}
