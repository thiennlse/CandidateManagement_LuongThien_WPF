using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class JobPostingRepo : IJobPostingRepo
    {
        private CandidateManagementContext _context;
        private static JobPostingRepo _instance;

        public JobPostingRepo()
        {
            _context = new CandidateManagementContext();
        }

        public static JobPostingRepo Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new JobPostingRepo();
                }
                return _instance;
            }
        }

        List<JobPosting> _jobs;

        public List<JobPosting> GetJobs()
        {
            return _context.JobPostings.ToList();
        }

        public JobPosting GetJob(string id)
        {
            return _context.JobPostings.SingleOrDefault(x => x.PostingId.Equals(id));
        }

        public void addJobPosting(JobPosting job)
        {
            _context.JobPostings.Add(job);
            _context.SaveChanges();
        }

        public void deleteJobPosting(string id)
        {
            if(GetJob(id) != null)
            {
                _context.JobPostings.Remove(GetJob(id));
                _context.SaveChanges();
            }
        }

        public void updateJobPosting(string id,  JobPosting job) 
        {
            if (GetJob(id) != null)
            {
                JobPosting jobPosting = GetJob(id);
                jobPosting.JobPostingTitle = job.JobPostingTitle;
                jobPosting.Description = job.Description;
                jobPosting.CandidateProfiles = job.CandidateProfiles;

                _context.JobPostings.Update(jobPosting);
                _context.SaveChanges();
            }
            
        }
    }
}
