using FrontierCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontierCodingTest.Services
{
    public interface IAcountService
    {
         Task<List<Account>> GetAccounts();

        List<AccountsByStatus> GetAccountsByStatus(List<FrontierCodingTest.Models.Account> accounts);

    }
}
