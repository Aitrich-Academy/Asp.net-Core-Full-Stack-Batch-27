using AutoMapper;
using Domain.Helpers;
using Domain.Models;

using Domain.Service.Login.Interfaces;
using Domain.Service.SignUp.DTOs;
using Domain.Service.SignUp.Interfaces;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using HireMeNow_WebApi.Controllers;
using HireMeNow_WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace HireMeNow_WebApi.API.JobSeeker
{
	[ApiController]



	public class JobSeekerController : BaseApiController<JobSeekerController>
	{
		public ISignUpRequestService jobSeekerService { get; set; }

		public ILoginRequestService loginRequestService { get; set; }

		public IMapper mapper { get; set; }
		public JobSeekerController(ISignUpRequestService _jobSeekerService, IMapper _mapper, ILoginRequestService _loginRequestService)
		{
			jobSeekerService = _jobSeekerService;
			loginRequestService = _loginRequestService;
			mapper = _mapper;

			

		}
		[HttpPost]
		[Route("job-seeker/signup")]
		public async Task<ActionResult> createJobSeekerSignupRequest(JobSeekerSignupRequest data)
		{
			var jobSeekerSignupRequestDto = mapper.Map<JobSeekerSignupRequestDto>(data);
			jobSeekerService.CreateSignupRequest(jobSeekerSignupRequestDto);
			return Ok(data);
		}
		[HttpGet]
		[Route("job-seeker/signup/{jobSeekerSignupRequestId}/verify-email")]
		public async Task<ActionResult> VerifyJobSeekerEmail(Guid jobSeekerSignupRequestId)
		{
			var isVerified = await jobSeekerService.VerifyEmailAsync(jobSeekerSignupRequestId);
			if (isVerified)
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpPost]
		[Route("job-seeker/signup/{jobSeekerSignupRequestId}/set-password")]
		public async Task<ActionResult> createJobSeekerSignupRequest(Guid jobSeekerSignupRequestId, [FromBody] string password)
		{
			//var jobSeekerSignupRequestDto = mapper.Map<JobSeekerSignupRequestDto>(data);
			await jobSeekerService.CreateJobseeker(jobSeekerSignupRequestId, password);
			return Ok("Password Set Successfully");
		}




		[HttpPost]
		[Route("job-seeker/login")]
		public async Task<ActionResult> Login(JobSeekerLoginRequest logdata)
		{
			//var user = _mapper.Map<User>(userDto);
			var user = loginRequestService.login(logdata.Email, logdata.Password);

			if (user == null)
			{
				return BadRequest("Login Failed");
			}
			return Ok(user);
		}
	
	
	}
}
