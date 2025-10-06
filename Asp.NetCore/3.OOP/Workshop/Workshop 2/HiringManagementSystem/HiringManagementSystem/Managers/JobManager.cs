using HiringManagementSystem.Interface;
using HiringManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringManagementSystem.Managers
{
    public class JobManager:IJob
    {
        private Job[] _jobs = new Job[100];  // fixed size array (max 100 jobs)
        private int _count = 0;              // to track how many jobs are added

        public void AddJob(Job job)
        {
            if (_count < _jobs.Length)
            {
                job.Id = _count + 1;
                _jobs[_count] = job;
                _count++;
            }
            else
            {
                Console.WriteLine("Job list is full. Cannot add more jobs.");
            }
        }

        public Job[] GetJobs()
        {
            // return only filled jobs (not the null slots)
            Job[] result = new Job[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = _jobs[i];
            }
            return result;
        }
    }
}
