using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using WorldTravel.Dtos.Forms;
using WorldTravel.Models.Results.Abstract;

namespace WorldTravel.Abstract
{
    public interface IFormAppService : ICrudAppService<FormDto, int, PagedAndSortedResultRequestDto, CreateUpdateFormDto, CreateUpdateFormDto>
    {
    }
}
