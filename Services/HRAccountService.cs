using Models.Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HRAccountService : IHRAccountService
    {
        private readonly HRAccountRepo _repo;

        public Hraccount getAccount(string email, string password)
        {
            return HRAccountRepo.Instance.getAccount(email, password);
        }

    }
}
