using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Money.Model.Entity;
using Money.WebApp.ViewModel;

namespace Money.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;

        public AccountController(IMapper mapper)
        {
            this.mapper = mapper;
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
    }
}