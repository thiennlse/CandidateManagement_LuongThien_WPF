using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Services;
namespace RunS
{
    internal class AccountR : IAccountR
    {
        private IHRAccountService HRAccountService;
        public AccountR() 
        {
            HRAccountService = new HRAccountService();
        }
        public Hraccount getAccount(string email, string password)
        {
            return HRAccountService.getAccount(email, password);
        }
    }
}
