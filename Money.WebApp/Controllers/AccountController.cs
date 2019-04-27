using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Money.Domain.Interface;
using Money.Model.Entity;
using Money.WebApp.ViewModel;

namespace Money.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IAccountService accountService;

        public AccountController(IMapper mapper, IAccountService accountService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        [HttpGet("[action]")]
        public IEnumerable<AccountVm> GetAll()
        {
            return mapper.Map<IEnumerable<AccountVm>>(accountService.GetAll());
        }

        [HttpGet("[action]")]
        public AccountVm TestAutomapper()
        {
            var account = new Account
            {
                Id = 100,
                Name = "Credit Card",
                Transactions = null
            };

            return mapper.Map<AccountVm>(account);
        }

        [HttpGet("[action]")]
        public IEnumerable<AccountVm> AddSomeAccounts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                accountService.Save(new Account
                {
                    Name = $"Account #{i + 1}"
                });
            }
            return mapper.Map<IEnumerable<AccountVm>>(accountService.GetAll());
        }
    }
}