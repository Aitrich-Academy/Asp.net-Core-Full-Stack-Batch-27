using AutoMapper;
using Domain.Models;

using Domain.Service.Authuser.DTOs;

using Domain.Service.Profile;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using Domain.Service.SignUp.DTOs;

using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MassTransit.ValidationResultExtensions;

namespace HireMeNow_WebApi.JobSeeker
{

    [ApiController]
    [Authorize(Roles = "JOB_SEEKER")]
    public class JobSeekerProfileController : BaseApiController<JobSeekerProfileController>

    {
        private readonly IJobSeekerProfileService _profileService;
        public IMapper mapper { get; set; }
        public JobSeekerProfileController(IJobSeekerProfileService profileService, IMapper _mapper)
        {
            mapper = _mapper;
            _profileService = profileService;
        }

    

        [HttpPost]
        [Route("{jobseekerId}/profile/{profileId}/Qualification")]
        public async Task<ActionResult> AddQualificationToProfile(Guid jobseekerId, Guid profileId, QualificationRequest data)
        {
            var JobseekerQualificationDTo = mapper.Map<JobseekerQualificationDTo>(data);
            _profileService.AddQualificationToProfileAsync(jobseekerId, profileId, JobseekerQualificationDTo);
            return Ok(data);
        }
        [HttpGet("{jobseekerId}/profiledetails")]
        public ActionResult<List<JobSeekerProfileDTo>> GetProfile(Guid jobseekerId)
        {
            var Profile = _profileService.GetProfile(jobseekerId);

            if (Profile == null || !Profile.Any())
                return NotFound();

            return Ok(Profile);


        }
       

        [HttpGet]
        [Route("/profile/{profileId}/Qualification")]
        public ActionResult<List<JobseekerQualificationDTo>> GetQualification(Guid profileId)
        {
            var Qualification = _profileService.GetQualification(profileId);

            if (Qualification == null || !Qualification.Any())
                return NotFound();

            return Ok(Qualification);
        }

     

    

       
        [HttpPut("UpdateJobSeekerProfile")]

        public async Task<IActionResult> UpdateJobSeekerProfile( [FromForm]AuthUserDTO updatedProfile)
        {
            try
            {
                var result =await _profileService.UpdateJobSeekerProfile(updatedProfile);

     
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

     

        //
        [HttpPost("AddProfile")]
        public async Task<IActionResult> AddProfile(JobseekerProfileRequest profileRequest)
        {
            var AddProfileDto = mapper.Map<ProfileDTO>(profileRequest);
            var addedProfile = await _profileService.AddProfileAsync(AddProfileDto);
            if (addedProfile)
                return Ok("Profile Added successfully");

            return BadRequest("Failed to Add Profile");
        }
        [HttpGet("GetJobSeekerProfile/{jobSeekerId}")]
        public async Task<IActionResult> GetProfilesByJobSeekerId(Guid jobSeekerId)
        {
            var profiles = await _profileService.GetProfilesByJobSeekerIdAsync(jobSeekerId);
            return Ok(profiles);
        }


    }
}
