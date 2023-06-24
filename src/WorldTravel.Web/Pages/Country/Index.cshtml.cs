using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldTravel.Abstract;
using WorldTravel.Dtos.CountryContents;
using WorldTravel.Dtos.CountryContents.ViewModels;

namespace WorldTravel.Web.Pages.Country
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CountryContentViewModel> CountryContent { get; set; }

        private readonly ICountryContentAppService _countryContentAppService;

        public IndexModel(ICountryContentAppService countryContentAppService)
        {
            _countryContentAppService = countryContentAppService;
        }
        public async Task<IActionResult> OnGet()
        {
            CountryContent = await _countryContentAppService.GetCountryContentListForUserAsync(new GetCountryContentRequestDto());

            return Page();
        }
    }
}
