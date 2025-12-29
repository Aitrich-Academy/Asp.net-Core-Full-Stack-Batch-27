

using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
	public interface IJobRepository
	{


		Task<List<JobPost>> GetJobs();
		Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId,JobListParams param);

		

    }

}
