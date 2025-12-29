using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.SignUp.Interfaces
{
    public interface ISignupRequestRepository
    {
        Task AddJobSeekerAsync(Models.JobSeeker jobseeker);
        Guid AddSignupRequest(SignupRequest signUpRequest);
        Task<SignupRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId);
        void UpdateSignupRequest(SignupRequest signUpRequest);
    }
}
