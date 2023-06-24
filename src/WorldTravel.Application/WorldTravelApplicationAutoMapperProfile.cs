using AutoMapper;
using Volo.Abp.Identity;
using WorldTravel.Dtos.CountryContents;
using WorldTravel.Dtos.CountryContents.ViewModels;
using WorldTravel.Dtos.Files;
using WorldTravel.Dtos.Forms;
using WorldTravel.Dtos.Forms.ViewModels;
using WorldTravel.Dtos.Users;
using WorldTravel.Dtos.Users.ViewModels;
using WorldTravel.Entities.CountryContents;
using WorldTravel.Entities.Files;
using WorldTravel.Entities.Forms;
using WorldTravel.Entities.Users;

namespace WorldTravel
{
    public class WorldTravelApplicationAutoMapperProfile : Profile
    {
        public WorldTravelApplicationAutoMapperProfile()
        {
            #region User
            CreateMap<AppUser, AppUserViewModel>();              //UserAppService > GetUserByIdAsync
            CreateMap<IdentityUserDto, IdentityUserUpdateDto>(); //UserAppService > ManageProfileAsync
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            #endregion


            #region File
            CreateMap<File, FileDto>().ReverseMap();//FileAppService > SaveFileAsync
            #endregion

            #region Form
            CreateMap<Form, FormDto>().ReverseMap();//Form/Index POST
            CreateMap<Form, CreateUpdateFormDto>().ReverseMap();//Form/Index POST
            CreateMap<Form, FormViewModel>().ReverseMap();//FormAopService > GetFormListAsync
            #endregion

            #region CountryContent
            CreateMap<CountryContent, CountryContentDto>().ReverseMap();
            CreateMap<CountryContent, CreateUpdateCountryContentDto>().ReverseMap();
            CreateMap<CountryContent, CountryContentViewModel>().ReverseMap();

            #endregion


        }
    }
}
