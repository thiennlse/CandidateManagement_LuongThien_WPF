using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class CandidateProfile
    {
        public CandidateProfile(string candidateId, string fullname, DateTime? birthday, string? profileShortDescription, string? profileUrl, string? postingId)
        {
            CandidateId = candidateId;
            Fullname = fullname;
            Birthday = birthday;
            ProfileShortDescription = profileShortDescription;
            ProfileUrl = profileUrl;
            PostingId = postingId;
        }

        public string CandidateId { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? ProfileShortDescription { get; set; }
        public string? ProfileUrl { get; set; }
        public string? PostingId { get; set; }

        public virtual JobPosting? Posting { get; set; }
    }
}
