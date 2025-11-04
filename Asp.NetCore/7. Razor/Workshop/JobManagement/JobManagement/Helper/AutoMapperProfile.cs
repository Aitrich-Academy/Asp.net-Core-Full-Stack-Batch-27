using AutoMapper;
using JobManagement.Dto;
using JobManagement.Model;

namespace JobManagement.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Jobs, JobDto>().ReverseMap();
        }
    }
}
