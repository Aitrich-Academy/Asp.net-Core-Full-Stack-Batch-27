using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Service.Profile
{
    public class ProfileService : IJobSeekerProfileService
    {
        public readonly IJobSeekerProfileRepository _profileRepository;
        IMapper mapper;
        public ProfileService(IJobSeekerProfileRepository profileRepository, IMapper _mapper)
        {
            mapper = _mapper;
            _profileRepository = profileRepository;
        }

        public async Task<bool> AddProfileAsync(ProfileDTO addProfileDto)
        {
            var profile = mapper.Map<JobSeekerProfile>(addProfileDto);
            await _profileRepository.AddProfileAsync(profile);
            return true;
        }

        public void AddQualificationToProfile(Guid jobseekerId, Guid profileId, Qualification qualification)
        {
            var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(qualification);
                _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }
        }


        public Task AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo)
        {
            var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(jobseekerQualificationDTo);
                return _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }
        }

       

        public async Task<JobSeekerProfileDTo> GetcompleateProfile(Guid jobseekerId)
        {
            var jobSeekerProfile = await _profileRepository.GetProfiledetailAsync(jobseekerId);

            if (jobSeekerProfile == null)
            {
                // Handle case when the profile is not found
                return null; // or throw an exception or handle it according to your application logic
            }

            var jobSeekerProfileDTO = new JobSeekerProfileDTo
            {
                UserName = jobSeekerProfile.JobSeeker.UserName,
                FirstName = jobSeekerProfile.JobSeeker.FirstName,
                LastName = jobSeekerProfile.JobSeeker.LastName,
                Phone = jobSeekerProfile.JobSeeker.Phone,
                Email = jobSeekerProfile.JobSeeker.Email,
                Qualification = jobSeekerProfile.Qualifications.ToList(),
                JobSeekerProfileSkills = jobSeekerProfile.JobSeekerProfileSkills.Select(s => s.Skill).ToList(),
                Role = jobSeekerProfile.JobSeeker.Role,
 
            };

            return jobSeekerProfileDTO;
        }

       

        public List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId)
        {
            return _profileRepository.GetProfile(jobseekerId);
        }

       

        public Task GetProfileDetailsAsync(Guid jobseekerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobSeekerProfile>> GetProfilesByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _profileRepository.GetProfilesByJobSeekerIdAsync(jobSeekerId);
        }

        public List<JobseekerQualificationDTo> GetQualification(Guid profileId)
        {

            var Qualifications = _profileRepository.GetQualification(profileId);
            var QualificationDtos = mapper.Map<List<JobseekerQualificationDTo>>(Qualifications);

            return QualificationDtos;

        }

      

        public async Task<AuthUserDTO> UpdateJobSeekerProfile(AuthUserDTO updatedProfile)
        {
            // Perform validation, mapping, and update logic if needed
            // Call the repository to update the JobSeeker's profile
            var result = await _profileRepository.UpdateProfile(updatedProfile);

            return result;
        }

        
    }
}

