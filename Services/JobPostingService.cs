using Models.Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JobPostingService : IJobPostingService
    {
        public void addJobPosting(JobPosting job)
        {
            JobPostingRepo.Instance.addJobPosting(job);
        }

        public void deleteJobPosting(string id)
        {
            JobPostingRepo.Instance.deleteJobPosting(id);
        }

        public JobPosting GetJob(string id)
        {
            return JobPostingRepo.Instance.GetJob(id);
        }

        public List<JobPosting> GetJobs()
        {
            return JobPostingRepo.Instance.GetJobs();
        }

        public void updateJobPosting(string id, JobPosting job)
        { 
            JobPostingRepo.Instance.updateJobPosting(id, job);
        }
    }
}
