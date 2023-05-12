using AutoMapper;
using Volo.Abp.Identity;
using WorldTravel.Dtos.Files;
using WorldTravel.Dtos.MessageContents;
using WorldTravel.Dtos.MessageContents.ViewModels;
using WorldTravel.Dtos.Messages;
using WorldTravel.Dtos.Messages.ViewModels;
using WorldTravel.Dtos.Users;
using WorldTravel.Dtos.Users.ViewModels;
using WorldTravel.Entities.Files;
using WorldTravel.Entities.MessageContents;
using WorldTravel.Entities.Messages;
using WorldTravel.Entities.Users;

namespace WorldTravel
{
    public class WorldTravelApplicationAutoMapperProfile : Profile
    {
        public WorldTravelApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */
            #region User
            CreateMap<AppUser, AppUserViewModel>();              //UserAppService > GetUserByIdAsync
            CreateMap<IdentityUserDto, IdentityUserUpdateDto>(); //UserAppService > ManageProfileAsync
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            #endregion


            #region Message
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();//MessageAppService > GetUserMessageListAsync

            #endregion

            #region MessageContent 
            CreateMap<MessageContent, MessageContentDto>().ReverseMap();
            CreateMap<MessageContent, MessageContentViewModel>().ReverseMap();
            #endregion

            #region File

            CreateMap<File, FileDto>().ReverseMap();//FileAppService > SaveFileAsync

            #endregion
        }
    }
}
