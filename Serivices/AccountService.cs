using FrontierCodingTest.Enums;
using FrontierCodingTest.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FrontierCodingTest.Services
{
    public class AccountService: IAcountService
    {
        private readonly IConfiguration iconfiguration;

        public AccountService()
        {
        }

        public async Task<List<Account>> GetAccounts()
        {
            var uri = "https://frontiercodingtests.azurewebsites.net/api/accounts/getall";
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);
                return JsonConvert.DeserializeObject<List<Account>>(await response.Content.ReadAsStringAsync());
            }
        }

        public List<AccountsByStatus> GetAccountsByStatus(List<FrontierCodingTest.Models.Account> accounts)
        {
            
            List <AccountsByStatus> accountsByStatuses = new List<AccountsByStatus>();
            AccountsByStatus accountsByStatusInactive = null;
            foreach (AccountStatus val in Enum.GetValues(typeof(AccountStatus)))
            {
                var selAccounts = accounts.Where(a => a.AccountStatusId == (int)val).OrderBy(a => a.PaymentDueDate).ToList();
                if (selAccounts.Count() > 0)
                {
                    AccountsByStatus accountsByStatus = new AccountsByStatus();
                    accountsByStatus.Status = val;
                    accountsByStatus.Accounts = selAccounts;

                    if (val == AccountStatus.Inactive)
                    {
                        accountsByStatusInactive = accountsByStatus;
                    }
                    else
                    {
                        accountsByStatuses.Add(accountsByStatus);
                    }

                }
            }
            if (accountsByStatusInactive != null)
            {
                accountsByStatuses.Add(accountsByStatusInactive);
            }
            return accountsByStatuses;
        }
    }
}