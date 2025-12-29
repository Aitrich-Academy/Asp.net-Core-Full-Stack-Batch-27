using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;

namespace Domain.Service.Profile.Interface
{
    public interface IJobSeekerProfileService
    {
        Task<bool> AddProfileAsync(ProfileDTO addProfileDto);
        Task AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo);
    
        List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId);
   
        Task<List<JobSeekerProfile>> GetProfilesByJobSeekerIdAsync(Guid jobSeekerId);
        List<JobseekerQualificationDTo> GetQualification(Guid profileId);
        Task <AuthUserDTO> UpdateJobSeekerProfile(AuthUserDTO updatedProfile);

    }
}
