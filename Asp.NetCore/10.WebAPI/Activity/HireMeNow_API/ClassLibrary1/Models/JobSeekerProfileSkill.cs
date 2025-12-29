using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobSeekerProfileSkill
    {
        public Guid Id { get; set; }
        public Guid JobSeekerProfileId { get; set; }
        public JobSeekerProfile JobSeekerProfile { get; set; }

        
        public string SkillName { get; set; }

        public string SkillDescription { get; set; }
    }
}
