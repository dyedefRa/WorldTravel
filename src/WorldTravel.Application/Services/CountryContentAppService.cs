using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using WorldTravel.Abstract;
using WorldTravel.Dtos.CountryContents;
using WorldTravel.Dtos.CountryContents.ViewModels;
using WorldTravel.Entities.CountryContents;
using WorldTravel.Enums;
using WorldTravel.Localization;
using WorldTravel.Permissions;

namespace WorldTravel.Services
{
    [Authorize(WorldTravelPermissions.CountryContent.Default)]
    public class CountryContentAppService : CrudAppService<CountryContent, CountryContentDto, int, PagedAndSortedResultRequestDto, CreateUpdateCountryContentDto, CreateUpdateCountryContentDto>, ICountryContentAppService
    {
        private readonly IStringLocalizer<WorldTravelResource> _L;

        public CountryContentAppService(
            IRepository<CountryContent, int> repository,
            IStringLocalizer<WorldTravelResource> L
            ) : base(repository)
        {
            _L = L;
        }

        public async Task<PagedResultDto<CountryContentViewModel>> GetCountryContentListAsync(GetCountryContentRequestDto input)
        {
            var result = new PagedResultDto<CountryContentViewModel>();

            var query = Repository.Where(x => x.Status == Status.Active).AsQueryable();
            query = query
                .Include(x => x.Country)
                .Include(x => x.CountryContentFiles).ThenInclude(x => x.File);

            query = query
                .WhereIf(!string.IsNullOrWhiteSpace(input.CountryNameFilter), x => x.Country.Title.Contains(input.CountryNameFilter));

            var totalCount = await query.CountAsync();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var list = await query.ToListAsync();
            var viewModels = list.Select(x =>
            {
                var files = x.CountryContentFiles.Select(x => x.File).ToList();
                var viewModel = ObjectMapper.Map<CountryContent, CountryContentViewModel>(x);
                viewModel.CountryName = x.Country.Title;
                if (files != null)
                {
                    var images = files.Where(x => x.FileType == FileType.Image).ToList();
                    if (images.Count > 0)
                    {
                        viewModel.PreviewImageUrl = images.OrderBy(x => x.Rank).FirstOrDefault().Path;
                        viewModel.TotalImageCount = images.Count;
                    }
                    var videos = files.Where(x => x.FileType == FileType.Video).ToList();
                    if (videos.Count > 0)
                    {
                        viewModel.TotalVideoCount = videos.Count;
                    }
                }
                return viewModel;
            }).ToList();

            result.Items = viewModels;
            result.TotalCount = totalCount;
            return result;
        }


    }
}
