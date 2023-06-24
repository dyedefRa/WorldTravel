using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WorldTravel.Abstract;
using WorldTravel.Dtos.CountryContents.ViewModels;

namespace WorldTravel.Web.Pages.Country
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public CountryContentViewModel CountryContent { get; set; }

        private readonly ICountryContentAppService _countryContentAppService;
        public DetailModel(ICountryContentAppService countryContentAppService)
        {
            _countryContentAppService = countryContentAppService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var data= await _countryContentAppService.GetCountryContentAsync(id);
            if (!data.Success)
                return Redirect("~/Error?httpStatusCode=404");

           
            CountryContent = data.Data;

            return Page();
        }
    }
}
