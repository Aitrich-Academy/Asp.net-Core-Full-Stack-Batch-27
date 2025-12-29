using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.SignUp.DTO;

namespace Domain.Services.SignUp.Interfaces
{
    public interface ISignupRequestService
    {
        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);

       
        void CreateSignupRequest(JobSeekerSignupRequestDto data);

        Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId);

    }
}
