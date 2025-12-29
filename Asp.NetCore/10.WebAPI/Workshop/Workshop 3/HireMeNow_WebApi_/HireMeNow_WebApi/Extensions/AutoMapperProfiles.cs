
using AutoMapper;
using Domain.Models;
using Domain.Service.Login.DTOs;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using Domain.Service.Profile.DTOs;
using HireMeNow_WebApi.JobSeeker;



namespace HireMeNow_WebApi.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
          
            CreateMap<JobSeekerSignupRequestDto, SignUpRequest>().ReverseMap();
			CreateMap<JobSeekerSignupRequest, JobSeekerSignupRequestDto>().ReverseMap();

            CreateMap<JobProviderSignupRequestDto, SignUpRequest>().ReverseMap();


            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyUser>().ReverseMap();
        
      
            CreateMap<Qualification,QualificationsRequestDto>().ReverseMap();
            CreateMap<QualificationRequest, JobseekerQualificationDTo>();
            CreateMap<Qualification,JobseekerQualificationDTo>();
        
            CreateMap<JobseekerQualificationDTo, Qualification>();
            CreateMap<WorkExperieceRequest, JobseekerWorkExperienceDTo>();
            CreateMap<JobseekerWorkExperienceDTo, WorkExperience>();
            CreateMap<WorkExperience, ExperienceDto>();
            CreateMap<AuthUser, JobSeekerLoginDto>();
            CreateMap<AuthUser, JobSeekerLoginDto>();
            CreateMap<JobSeekerProfileDTo, Domain.Models.JobSeeker>();
            CreateMap<ApplyJobRequest, JobApplication>();
            CreateMap<JobSeekerProfile, ProfileDTO>();
            CreateMap<ProfileDTO,JobseekerProfileRequest>();
            CreateMap<JobseekerProfileRequest, ProfileDTO>();
            CreateMap<ProfileDTO, JobSeekerProfile>();      
        }
    }
}
