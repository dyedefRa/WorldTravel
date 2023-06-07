using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using WorldTravel.Dtos.CountryContents;

namespace WorldTravel.Abstract
{
    public interface ICountryContentAppService : ICrudAppService<CountryContentDto, int, PagedAndSortedResultRequestDto, CreateUpdateCountryContentDto, CreateUpdateCountryContentDto>
    {
    }
}
