using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldTravel.Abstract;
using WorldTravel.Dtos.CountryContents;
using WorldTravel.Dtos.CountryContents.ViewModels;
using WorldTravel.Dtos.VisaTypes;
using WorldTravel.Dtos.VisaTypes.ViewModels;

namespace WorldTravel.Web.Pages.Country
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CountryContentViewModel> CountryContent { get; set; }
        [BindProperty]
        public List<VisaTypeViewModel> VisaType { get; set; }

        private readonly ICountryContentAppService _countryContentAppService;
        private readonly IVisaTypeAppService _visaTypeAppService;

        public IndexModel(
            ICountryContentAppService countryContentAppService,
            IVisaTypeAppService visaTypeAppService
            )
        {
            _countryContentAppService = countryContentAppService;
            _visaTypeAppService = visaTypeAppService;
        }
        public async Task<IActionResult> OnGet()
        {
            CountryContent = await _countryContentAppService.GetCountryContentListForUserAsync(new GetCountryContentRequestDto());
            VisaType = await _visaTypeAppService.GetVisaTypeListForUserAsync(new GetVisaTypeRequestDto() { IsSeenHomePage = true });
            return Page();
        }
    }
}
