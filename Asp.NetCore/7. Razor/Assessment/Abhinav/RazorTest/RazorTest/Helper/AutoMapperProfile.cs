using AutoMapper;
using RazorTest.Dto;
using RazorTest.Model;

namespace RazorTest.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {

            CreateMap<Book,BookDto>().ReverseMap();
        }
    }
}
