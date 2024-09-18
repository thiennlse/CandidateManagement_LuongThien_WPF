using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IHRAccountService
    {
        public Hraccount getAccount(string email, string password);
    }
}
