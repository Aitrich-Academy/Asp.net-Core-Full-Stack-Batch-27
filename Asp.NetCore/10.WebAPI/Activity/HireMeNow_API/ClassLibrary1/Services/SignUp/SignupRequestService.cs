using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassLibrary1.Enum;
using Domain.Helpers;
using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.Email.Interface;
using Domain.Services.SignUp.DTO;
using Domain.Services.SignUp.Interfaces;

namespace Domain.Services.SignUp
{
    public class SignupRequestService : ISignupRequestService
    {
        ISignupRequestRepository jobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        IEmailService emailService;

        public SignupRequestService(ISignupRequestRepository jobSeekerRepository, IAuthUserRepository authUserRepository, IMapper mapper, IEmailService emailService)
        {
            this.jobSeekerRepository = jobSeekerRepository;
            this.authUserRepository = authUserRepository;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignupRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);


                if (signUpRequest.Status == Status.VERIFIED)
                {
                    Domain.Models.AuthUser authUser = mapper.Map<Domain.Models.AuthUser>(signUpRequest);
                    authUser.Password = password;
                   
                    authUser = await authUserRepository.AddAuthUser(authUser);
                    signUpRequest.Status = Status.CREATED;
                    jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void CreateSignupRequest(JobSeekerSignupRequestDto data)
        {
            var signUpRequest = mapper.Map<SignupRequest>(data);
            var signUpId = jobSeekerRepository.AddSignupRequest(signUpRequest);
            MailRequest mailRequest = new MailRequest();

            mailRequest.Subject = "HireMeNow SignUp Verification";
            mailRequest.Body = "Hello" + signUpId.ToString();
            mailRequest.ToEmail = signUpRequest.Email;
            await emailService.SendEmailAsync(mailRequest);
        }

        public async Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId)
        {
            SignupRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
            if (signUpRequest != null)
            {
                signUpRequest.Status = Status.VERIFIED;
                jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                return true;
            }
            return false;
        }
    }
}
