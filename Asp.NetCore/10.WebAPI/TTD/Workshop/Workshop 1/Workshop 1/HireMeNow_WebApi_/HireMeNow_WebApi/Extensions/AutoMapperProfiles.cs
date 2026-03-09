
using AutoMapper;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.Login.DTOs;
using Domain.Service.Job.DTOs;
using Domain.Service.Profile.DTOs;
using Domain.Service.Admin.DTOs;

using HireMeNow_WebApi.API.Admin.RequestObjects;

namespace HireMeNow_WebApi.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {


            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyUser>().ReverseMap();
            CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
           
       
            CreateMap<Skill, SkillDto>();
            CreateMap<JobseekerQualificationDTo, Qualification>();
      
            CreateMap<JobseekerWorkExperienceDTo, WorkExperience>();
            CreateMap<WorkExperience, ExperienceDto>();
            CreateMap<AuthUser, JobSeekerLoginDto>();
            CreateMap<Industry, IndustryRequest>().ReverseMap();
            CreateMap<JobCategory, CategoryRequest>().ReverseMap();
            CreateMap<Location, LocationRequest>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<JobProviderCompany, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();


            CreateMap<AuthUser, JobSeekerLoginDto>();
            CreateMap<JobPost, Joblist>().ReverseMap();
            CreateMap<AuthUser, AdminLoginDTO>();

            CreateMap<JobSeekerProfileDTo, Domain.Models.JobSeeker>();
          
       
            CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
            CreateMap<Domain.Models.JobSeeker, JobSeekerDto>().ReverseMap();
            CreateMap<JobProviderCompany, Domain.Service.Admin.DTOs.JobProviderDto>().ReverseMap();
         
            CreateMap<JobSeekerProfile, ProfileDTO>();
          
            CreateMap<ProfileDTO, JobSeekerProfile>();
            CreateMap<SkillRequest, SkillDto>();
            CreateMap<SkillDto, Skill>();

        }
    }
}
