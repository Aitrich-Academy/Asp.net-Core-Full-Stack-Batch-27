using AutoMapper;
using BlazorAssessment.Dto;
using BlazorAssessment.Models;

namespace BlazorAssessment.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Taskk,TaskkDto>().ReverseMap();
        }
    }
}
