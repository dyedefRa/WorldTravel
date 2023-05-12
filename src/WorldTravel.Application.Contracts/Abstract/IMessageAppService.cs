using WorldTravel.Dtos.Messages;
using WorldTravel.Dtos.Messages.ViewModels;
using WorldTravel.Models.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace WorldTravel.Abstract
{
    public interface IMessageAppService : ICrudAppService<MessageDto, int, PagedAndSortedResultRequestDto, MessageDto, MessageDto>
    {
        Task<IDataResult<List<MessageViewModel>>> GetUserMessageListAsync();
        Task<IDataResult<List<MessageWithContentViewModel>>> GetUserMessageWithContentListAsync(int messageId);
    }
}
