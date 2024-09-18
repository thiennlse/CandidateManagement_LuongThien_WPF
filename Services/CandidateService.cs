using Models.Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CandidateService : ICandidateService
    {
        public void addCandidate(CandidateProfile profile)
        {
            CandidateRepo.Instance.addCandidate(profile);
        }

        public CandidateProfile GetProfile(string id)
        {
            return CandidateRepo.Instance.GetProfile(id);
        }

        public List<CandidateProfile> GetProfiles()
        {
            return CandidateRepo.Instance.GetProfiles();
        }

        public void removeCandidate(string id)
        {
            CandidateRepo.Instance.removeCandidate(id);
        }

        public void updateCandidate(string id, CandidateProfile profile)
        {
            CandidateRepo.Instance.updateCandidate(id, profile);
        }
    }
}
