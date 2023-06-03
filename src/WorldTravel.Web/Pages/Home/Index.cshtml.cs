using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WorldTravel.Abstract;
using WorldTravel.Enums;

namespace WorldTravel.Web.Pages.Home
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public HomeSelectModel HomeSelectInputModel { get; set; }
        public List<SelectListItem> Countries { get; set; }
        private readonly ILookupAppService _lookupAppService;

        public IndexModel(
            ILookupAppService lookupAppService
            )
        {
            _lookupAppService = lookupAppService;
        }

        public async Task OnGet()
        {
            HomeSelectInputModel = new HomeSelectModel();
            Countries = await _lookupAppService.GetCountryLookupAsync();
        }


        public class HomeSelectModel
        {
            [Required]
            public int CountryId { get; set; }
       
        }
    }
}
