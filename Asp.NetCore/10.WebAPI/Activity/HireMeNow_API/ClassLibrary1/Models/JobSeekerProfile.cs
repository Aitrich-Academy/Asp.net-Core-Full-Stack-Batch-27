using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobSeekerProfile
    {
        [Key]
        [Required]
        
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? ResumeId { get; set; }
        [ForeignKey(nameof(JobSeeker))]
        public Guid JobSeekerId { get; set; }

        public string? ProfileName { get; set; }

        public string? ProfileSummary { get; set; }
        [JsonIgnore]
        public  Resume? Resume { get; set; } = null!;

        public JobSeeker JobSeeker { get; set; }
        [JsonIgnore]
        public List<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }
        [JsonIgnore]
        public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
        [JsonIgnore]
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
    }

}

