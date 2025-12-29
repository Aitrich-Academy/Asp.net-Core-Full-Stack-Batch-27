using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Enum;
using Domain.Models;
using Domain.Services.SignUp.Interfaces;

namespace Domain.Services.SignUp
{
    public class SignupRequestRepository : ISignupRequestRepository
    {
        protected readonly AppDbContext _context;

        public SignupRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddJobSeekerAsync(JobSeeker jobseeker)
        {
            await _context.JobSeekers.AddAsync(jobseeker);
            await _context.SaveChangesAsync();
        }

        public Guid AddSignupRequest(SignupRequest signUpRequest)
        {
            signUpRequest.Status = Status.PENDING;
            _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;
        }

        public async Task<SignupRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId)
        {
            return await _context.SignUpRequests.FindAsync(jobSeekerSignupRequestId);
        }

        public void UpdateSignupRequest(SignupRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
            _context.SaveChanges();
        }
    }
}
