using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using WorldTravel.Abstract;
using WorldTravel.Dtos.Forms;
using WorldTravel.Dtos.Forms.ViewModels;
using WorldTravel.Entities.Forms;
using WorldTravel.Enums;
using WorldTravel.Localization;
using WorldTravel.Models.Results.Abstract;
using WorldTravel.Models.Results.Concrete;
using WorldTravel.Permissions;

namespace WorldTravel.Services
{
    [Authorize(WorldTravelPermissions.Form.Default)]
    public class FormAppService : CrudAppService<Form, FormDto, int, PagedAndSortedResultRequestDto, CreateUpdateFormDto, CreateUpdateFormDto>, IFormAppService
    {
        private readonly IStringLocalizer<WorldTravelResource> _L;

        public FormAppService(
            IRepository<Form, int> repository,
            IStringLocalizer<WorldTravelResource> L
          ) : base(repository)
        {
            _L = L;
        }

        public async Task<PagedResultDto<FormViewModel>> GetFormListAsync(GetFormRequestDto input)
        {
            var result = new PagedResultDto<FormViewModel>();

            var query = Repository.Where(x => x.Status == Status.Active).AsQueryable();
            query = query.Include(x => x.Country);

            query = query
                .WhereIf(!string.IsNullOrWhiteSpace(input.FullNameFilter), x => (x.Name.Contains(input.FullNameFilter) || (x.Surname.Contains(input.FullNameFilter))))
                .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), x => x.Email.Contains(input.EmailFilter))
                .WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter), x => x.PhoneNumber.Contains(input.PhoneFilter))
                .WhereIf(input.IsContactedFilter != BooleanType.Unstated, x => input.IsContactedFilter == BooleanType.True ? x.IsContacted == true : x.IsContacted == false);

            var totalCount = await query.CountAsync();

            //input.Sorting = "id desc";

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var list = await query.ToListAsync();
            var viewModels = list.Select(x =>
            {
                var viewModel = ObjectMapper.Map<Form, FormViewModel>(x);
                viewModel.FullName = x.Name + " " + x.Surname;
                viewModel.CountryName = x.Country.Title;
                return viewModel;
            }).ToList();

            result.Items = viewModels;
            result.TotalCount = totalCount;
            return result;
        }

        [IgnoreAntiforgeryToken]
        [Authorize(WorldTravelPermissions.Form.Edit)]
        public async Task<IDataResult<string>> UpdateFormIsContactedAsync(int id)
        {
            try
            {
                var entity = await Repository.FirstOrDefaultAsync(x => x.Status == Status.Active && x.Id == id);
                if (entity == null)
                    return new ErrorDataResult<string>(_L["EntityNotFoundError"].Value);

                entity.IsContacted = !entity.IsContacted;
                await Repository.UpdateAsync(entity, true);

                return new SuccessDataResult<string>(_L["SuccessfullyCompleted"].Value);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "FormAppService > GetUserMessageWithContentListAsync has error! ");
            }

            return new ErrorDataResult<string>(_L["GeneralError"].Value);
        }

        //[IgnoreAntiforgeryToken]
        //public async Task SoftDeleteAsync(int Id)
        //{
        //    var entity = Repository.FirstOrDefault(x => x.Id == Id);
        //    entity.Status = Status.Deleted;
        //    await Repository.UpdateAsync(entity);
        //}

    }
}
