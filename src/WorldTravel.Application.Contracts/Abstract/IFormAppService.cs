using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using WorldTravel.Dtos.Forms;

namespace WorldTravel.Abstract
{
    public interface IFormAppService : ICrudAppService<FormDto, int, PagedAndSortedResultRequestDto, CreateUpdateFormDto, CreateUpdateFormDto>
    {
    }
}
