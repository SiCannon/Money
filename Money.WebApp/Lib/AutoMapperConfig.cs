using AutoMapper;
using Money.Model.Entity;
using Money.WebApp.ViewModel;

namespace Money.WebApp.Lib
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Account, AccountVm>();
        }
    }
}
