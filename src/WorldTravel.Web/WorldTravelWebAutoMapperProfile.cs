using AutoMapper;
using Volo.Abp.Identity;
using WorldTravel.Dtos.Users.ViewModels;
using static WorldTravel.Web.Pages.Account.ManageModel;
using static WorldTravel.Web.Pages.Account.RegisterModel;

namespace WorldTravel.Web
{
    public class WorldTravelWebAutoMapperProfile : Profile
    {
        public WorldTravelWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            #region User
            CreateMap<UserRegisterModel, IdentityUserCreateDto>();//Account/Register

            CreateMap<AppUserViewModel, UserManageModel>(); //Account/Manage/OnGetAsync

            #endregion
        }
    }
}
