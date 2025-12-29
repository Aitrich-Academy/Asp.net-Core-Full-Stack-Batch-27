
using Domain.Models;
using Domain.Service.Job.Interfaces;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using Domain.Service.Login.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace Domain.Service.Job
{
    public class JobServices : IJobServices
    {
        private IJobRepository _jobrepository;
        private IMapper _mapper;

        public JobServices(IJobRepository jobrepository, IMapper mapper)
        {
            _jobrepository = jobrepository;
            _mapper = mapper;
        }
        public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId, JobListParams param)
        {
            var savedJobs = await _jobrepository.GetAllSavedJobsOfSeeker(jobseekerId, param);
            //var savedjobsDto = _mapper.Map<PagedList<SavedJob>>(savedJobs);
            return savedJobs;
        }

      
		public async Task<List<JobPostsDtos>> GetJobs()
		{
			var notApplied = await _jobrepository.GetJobs();
			var dtoList = _mapper.Map<List<JobPostsDtos>>(notApplied);
			return dtoList;

			
		}

	

     
		


    }

}
