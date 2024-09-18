using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RunS
{
    public interface IAccountR
    {
        public Hraccount getAccount(string email, string password);
    }
}
