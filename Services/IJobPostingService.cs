using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobs();
        public JobPosting GetJob(string id);
        public void addJobPosting(JobPosting job);
        public void deleteJobPosting(string id);
        public void updateJobPosting(string id, JobPosting job);
    }
}
