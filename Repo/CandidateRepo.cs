using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class CandidateRepo
    {
        private CandidateManagementContext _context;
        private static CandidateRepo _instance;

        public CandidateRepo()
        {
            _context = new CandidateManagementContext();
        }

        public static CandidateRepo Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CandidateRepo();
                }
                return _instance;
            }
        }

        List<CandidateProfile> _profiles;

        public List<CandidateProfile> GetProfiles()
        {
            return _context.CandidateProfiles.ToList();
        }

        public CandidateProfile GetProfile(string id)
        {
            return _context.CandidateProfiles.SingleOrDefault(x => x.CandidateId.Equals(id));
        }

        public void addCandidate(CandidateProfile profile) 
        {
            _context.CandidateProfiles.Add(profile);
            _context.SaveChanges();
        }

        public void updateCandidate(string id, CandidateProfile profile)
        {
            if(GetProfile(id) != null)
            {
                CandidateProfile profileOld = GetProfile(id); 
                profileOld.Fullname = profile.Fullname;
                profileOld.ProfileUrl = profile.ProfileUrl;
                profileOld.Birthday = profile.Birthday;
                profileOld.PostingId = profile.PostingId;
                profileOld.ProfileShortDescription = profile.ProfileShortDescription;

                _context.CandidateProfiles.Update(profileOld);
                _context.SaveChanges();

            }
        }

        public void removeCandidate(string id) 
        {
            _context.CandidateProfiles.Remove(GetProfile(id));
            _context.SaveChanges();
        }
    }
}
