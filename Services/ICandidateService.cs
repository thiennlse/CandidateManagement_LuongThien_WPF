using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICandidateService
    {
        public List<CandidateProfile> GetProfiles();

        public CandidateProfile GetProfile(string id);

        public void addCandidate(CandidateProfile profile);

        public void updateCandidate(string id, CandidateProfile profile);

        public void removeCandidate(string id);
    }
}
