
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domain.Service.Job
{
    public class JobRepository : IJobRepository
    {

        DbHireMeNowWebApiContext _context;
        IMapper _mapper;
        static List<JobPost> joblist;

        public JobRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





		public async Task<List<JobPost>> GetJobs()
		{

            try
            {
                var jobs=await _context.JobPosts.Include(e => e.Location).Include(e => e.Industry).Include(e => e.Company).Include(e => e.PostedByNavigation).Include(e => e.JobCategory).ToListAsync();
                return jobs;
            }


			
			catch (Exception ex)
			{
				throw ex;

			}
		}


     

        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _context.JobPosts.Where(e => e.CompanyId == companyId && e.Id == jobId).ToListAsync();
        }



        public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId, JobListParams param)
        {

            var query = _context.SavedJobs
              .OrderByDescending(c => c.DateSaved).Where(e => e.SavedBy == jobseekerId).Include(e => e.JobPost).AsQueryable();
            return await PagedList<SavedJob>.CreateAsync(query,
            param.PageNumber, param.PageSize);
        }



      
     
       


    }

}

