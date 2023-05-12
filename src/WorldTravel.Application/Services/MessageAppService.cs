using WorldTravel.Abstract;
using WorldTravel.Dtos.MessageContents.ViewModels;
using WorldTravel.Dtos.Messages;
using WorldTravel.Dtos.Messages.ViewModels;
using WorldTravel.Entities.MessageContents;
using WorldTravel.Entities.Messages;
using WorldTravel.Enums;
using WorldTravel.Extensions;
using WorldTravel.Localization;
using WorldTravel.Models.Results.Abstract;
using WorldTravel.Models.Results.Concrete;
using WorldTravel.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace WorldTravel.Services
{
    [Authorize(WorldTravelPermissions.Message.Default)]
    public class MessageAppService : CrudAppService<Message, MessageDto, int, PagedAndSortedResultRequestDto, MessageDto, MessageDto>, IMessageAppService
    {
        private readonly IFileAppService _fileAppService;
        private readonly IStringLocalizer<WorldTravelResource> _L;
        private readonly IRepository<MessageContent, int> _messageContentRepository;

        public MessageAppService(
            IRepository<Message, int> repository,
            IFileAppService fileAppService,
            IStringLocalizer<WorldTravelResource> L,
            IRepository<MessageContent, int> messageContentRepository
            ) : base(repository)
        {
            _fileAppService = fileAppService;
            _L = L;
            _messageContentRepository = messageContentRepository;
        }


        [Authorize(WorldTravelPermissions.Message.See)]
        public async Task<IDataResult<List<MessageViewModel>>> GetUserMessageListAsync()
        {
            try
            {
                var currentUserId = CurrentUser.Id.Value;
                var query = Repository.Where(x => x.Status == Status.Active && (x.SenderId == currentUserId || x.ReceiverId == currentUserId)).AsQueryable();
                //query = query.Include(x => x.Sender).Include(x => x.Receiver);

                var list = await AsyncExecuter.ToListAsync(query);
                var viewModels = list
                    .Select(x =>
                    {

                        var viewModel = ObjectMapper.Map<Message, MessageViewModel>(x);
                        //var shownUser = x.SenderId == currentUserId ? x.Receiver : x.Sender;
                        //viewModel.ShownUserFullName = shownUser.Name + " " + shownUser.Surname;
                        //viewModel.ShownUserImageUrl = _fileAppService.SetDefaultImageIfFileIsNull(shownUser.ImageId, shownUser.Gender.Value);
                        //viewModel.ShownUserZodiacSign = shownUser.BirthDate.HasValue ? shownUser.BirthDate.Value.ToZodiacSign() : "";

                        return viewModel;
                    })
                    //.OrderByDescending(x => x.InsertedDate)
                    .ToList();

                return new SuccessDataResult<List<MessageViewModel>>(viewModels);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "UserAppService > GetAppUserAsync has error! ");

                return new ErrorDataResult<List<MessageViewModel>>(L["GeneralError"]);
            }
        }

        /// <summary>
        /// Seçilen kişiyle konuşulan message content lerini getirir. 
        /// Yani mesajlaşma geçmişini getirir.
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [Authorize(WorldTravelPermissions.Message.See)]
        public async Task<IDataResult<List<MessageWithContentViewModel>>> GetUserMessageWithContentListAsync(int messageId)
        {
            try
            {
                if (!CurrentUser.IsAuthenticated)
                    return new ErrorDataResult<List<MessageWithContentViewModel>>(_L["YouMustLogin"].Value);

                var currentUserId = CurrentUser.Id.Value;
                var isExist = Repository.Any(x => x.Id == messageId && (x.SenderId == currentUserId || x.ReceiverId == currentUserId));
                if (!isExist)
                    return new ErrorDataResult<List<MessageWithContentViewModel>>(_L["NotAllowedProcess"].Value);


                var query = Repository.Where(x => x.Status == Status.Active && x.Id == messageId).AsQueryable();
                //query = query.Include(x => x.Sender).Include(x => x.Receiver).Include(x => x.MessageContents);

                var list = await AsyncExecuter.ToListAsync(query);
                var viewModels = list
                    .Select(x =>
                    {
                        MessageWithContentViewModel viewModel = new MessageWithContentViewModel();
                        viewModel.MessageId = x.Id;
                        //var shownUser = x.SenderId == CurrentUser.Id.Value ? x.Receiver : x.Sender;
                        //viewModel.MessageId = x.Id;
                        //viewModel.ShownUserId = shownUser.Id;
                        //viewModel.ShownUserFullName = shownUser.Name + " " + shownUser.Surname;
                        //var shownUserImageUrl = _fileAppService.SetDefaultImageIfFileIsNull(shownUser.ImageId, shownUser.Gender.Value);
                        //viewModel.ShownUserImageUrl = shownUserImageUrl;

                        //foreach (var messagecontent in x.MessageContents.OrderByDescending(x => x.CreatedDate).Take(15))
                        foreach (var messagecontent in x.MessageContents.OrderByDescending(x => x.CreatedDate))
                        {
                            var messageContentViewModel = ObjectMapper.Map<MessageContent, MessageContentViewModel>(messagecontent);
                            messageContentViewModel.IsMine = messagecontent.SenderId == currentUserId;
                            messageContentViewModel.MessageSendDate = messagecontent.CreatedDate.ToMessageSendDateString();
                            //messageContentViewModel.IsTodayDivider
                            viewModel.MessageContents.Add(messageContentViewModel);
                        }
                        return viewModel;
                    })
                    //.OrderByDescending(x => x.InsertedDate)
                    .ToList();

                return new SuccessDataResult<List<MessageWithContentViewModel>>(viewModels);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "UserAppService > GetAppUserAsync has error! ");

                return new ErrorDataResult<List<MessageWithContentViewModel>>(_L["GeneralError"]);
            }
        }


        /// <summary>
        /// Kendi gönderdiği mesaj contenti yada karşıdaki gönderen kişinin mesaj contentini, KENDI profilinde silmesine yarar.
        /// </summary>
        /// <param name="messageContentId"></param>
        /// <returns></returns>
        //[Authorize(WorldTravelPermissions.Message.See)]
        //public async Task<IDataResult<List<MessageWithContentViewModel>>> DeleteMessageContentAsync(int messageContentId)
        //{
        //    try
        //    {
        //        if (!CurrentUser.IsAuthenticated)
        //            return new ErrorDataResult<List<MessageWithContentViewModel>>(_L["YouMustLogin"].Value);

        //        var currentUserId = CurrentUser.Id.Value;
        //        var isExist = await _messageContentRepository.GetAsync(messageContentId &&);
        //        var isExist = Repository.Any(x => x.Id == messageId && (x.SenderId == currentUserId || x.ReceiverId == currentUserId));
        //        if (!isExist)
        //            return new ErrorDataResult<List<MessageWithContentViewModel>>(_L["NotAllowedProcess"].Value);


        //        var query = Repository.Where(x => x.Status == Status.Active && x.Id == messageId).AsQueryable();
        //        query = query.Include(x => x.Sender).Include(x => x.Receiver).Include(x => x.MessageContents);

        //        var list = await AsyncExecuter.ToListAsync(query);
        //        var viewModels = list
        //            .Select(x =>
        //            {
        //                MessageWithContentViewModel viewModel = new MessageWithContentViewModel();
        //                viewModel.MessageId = x.Id;
        //                var shownUser = x.SenderId == CurrentUser.Id.Value ? x.Receiver : x.Sender;
        //                viewModel.MessageId = x.Id;
        //                viewModel.ShownUserId = shownUser.Id;
        //                viewModel.ShownUserFullName = shownUser.Name + " " + shownUser.Surname;
        //                var shownUserImageUrl = _fileAppService.SetDefaultImageIfFileIsNull(shownUser.ImageId, shownUser.Gender.Value);
        //                viewModel.ShownUserImageUrl = shownUserImageUrl;

        //                //foreach (var messagecontent in x.MessageContents.OrderByDescending(x => x.CreatedDate).Take(15))
        //                foreach (var messagecontent in x.MessageContents.OrderByDescending(x => x.CreatedDate))
        //                {
        //                    var messageContentViewModel = ObjectMapper.Map<MessageContent, MessageContentViewModel>(messagecontent);
        //                    messageContentViewModel.IsMine = messagecontent.SenderId == currentUserId;
        //                    messageContentViewModel.MessageSendDate = messagecontent.CreatedDate.ToMessageSendDateString();
        //                    //messageContentViewModel.IsTodayDivider
        //                    viewModel.MessageContents.Add(messageContentViewModel);
        //                }
        //                return viewModel;
        //            })
        //            //.OrderByDescending(x => x.InsertedDate)
        //            .ToList();

        //        return new SuccessDataResult<List<MessageWithContentViewModel>>(viewModels);

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "UserAppService > GetAppUserAsync has error! ");

        //        return new ErrorDataResult<List<MessageWithContentViewModel>>(_L["GeneralError"]);
        //    }
        //}


    }
}
