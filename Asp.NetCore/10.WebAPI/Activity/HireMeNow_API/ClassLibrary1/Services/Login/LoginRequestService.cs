using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.Login.DTOs;
using Domain.Services.Login.Interfaces;

namespace Domain.Services.Login
{
    public class LoginRequestService:ILoginRequestService
    {
        ILoginRequestRepository jobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;

        public LoginRequestService(ILoginRequestRepository jobSeekerRepository, IAuthUserRepository authUserRepository, IMapper mapper)
        {
            this.jobSeekerRepository = jobSeekerRepository;
            this.authUserRepository = authUserRepository;
            this.mapper = mapper;
        }

        public JobSeekerLoginDto Login(string email, string password)
        {
            var user = jobSeekerRepository.GetUserByEmailPassword(email, password);
            if(user == null)
            {
                return null;
            }
           
                var userReturn = mapper.Map<JobSeekerLoginDto>(user);
                userReturn.Token = authUserRepository.CreateToken(user);
                return userReturn;
           
        }
    }
}
