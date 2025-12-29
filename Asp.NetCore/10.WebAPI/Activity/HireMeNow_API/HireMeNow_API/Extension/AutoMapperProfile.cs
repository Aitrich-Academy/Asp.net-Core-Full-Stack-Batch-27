using AutoMapper;
using Domain.Models;
using Domain.Services.Login.DTOs;
using Domain.Services.SignUp.DTO;
using HireMeNow_API.API.JOBSeeker.RequestObjects;

namespace HireMeNow_API.Extension
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<JobSeeker, AuthUser>().ReverseMap();
            CreateMap<JobSeekerLoginDto, AuthUser>().ReverseMap();
            CreateMap<SignupRequest, AuthUser>().ReverseMap();
            CreateMap<JobSeekerSignupRequest, JobSeekerSignupRequestDto>().ReverseMap();
            CreateMap<JobSeekerSignupRequestDto, SignupRequest>().ReverseMap();

        }
    }
}
