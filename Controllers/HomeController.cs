using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontierCodingCore.Models;
using FrontierCodingTest.Services;
using FrontierCodingTest.Models;

namespace FrontierCodingCore.Controllers
{
    public class HomeController : Controller
    {
        readonly IAcountService _accountService;
        public HomeController(IAcountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<ActionResult> Index()
        {
            // IAcountService accountService = new AccountService();
            var accounts = await _accountService.GetAccounts();
            List<AccountsByStatus> accountsByStatus = _accountService.GetAccountsByStatus(accounts);
            ViewBag.AccountsByStatuses = accountsByStatus;
            return View();
        }

    
    }
}
