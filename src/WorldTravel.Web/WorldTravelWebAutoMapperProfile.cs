using AutoMapper;
using Volo.Abp.Identity;
using WorldTravel.Dtos.Forms;
using WorldTravel.Dtos.Users.ViewModels;
using static WorldTravel.Web.Pages.Account.ManageModel;
using static WorldTravel.Web.Pages.Account.RegisterModel;
using static WorldTravel.Web.Pages.Form.IndexModel;

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

            #region Form
            CreateMap<FormModel, CreateUpdateFormDto>();//Form/Index POST
            #endregion
        }
    }
}
