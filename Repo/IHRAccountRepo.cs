using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IHRAccountRepo
    {
        public Hraccount getAccount(string email, string password);
    }
}
