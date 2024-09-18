using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class HRAccountRepo : IHRAccountRepo
    {
        private readonly CandidateManagementContext _context;
        private static HRAccountRepo _instance;

        public HRAccountRepo()
        {
            _context = new CandidateManagementContext();
        }

        public static HRAccountRepo Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new HRAccountRepo();
                }
                return _instance;
            }
        }

        public Hraccount getAccount(string email, string password)
        {
            return _context.Hraccounts.SingleOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }
    }
}
