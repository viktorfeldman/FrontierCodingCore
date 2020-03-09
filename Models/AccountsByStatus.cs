using FrontierCodingTest.Models;
using FrontierCodingTest.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontierCodingTest.Models
{
    public class AccountsByStatus
    {
        public AccountStatus Status { get; set; }
        public List<Account> Accounts { get; set; }
    }
}