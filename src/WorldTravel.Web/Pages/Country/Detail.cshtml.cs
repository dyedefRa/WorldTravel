using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WorldTravel.Abstract;
using WorldTravel.Dtos.CountryContents.ViewModels;
using WorldTravel.Dtos.Forms;
using WorldTravel.Enums;

namespace WorldTravel.Web.Pages.Country
{
    [AutoValidateAntiforgeryToken]
    public class DetailModel : WorldTravelPageModel
    {
        [BindProperty]
        public CountryContentViewModel CountryContent { get; set; }
        [BindProperty]
        public FormModel Form { get; set; }
        public List<SelectListItem> Genders { get; set; }
        //public List<SelectListItem> Countries { get; set; }

        private readonly ICountryContentAppService _countryContentAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IFormAppService _formAppService;

        public DetailModel(
            ICountryContentAppService countryContentAppService,
            ILookupAppService lookupAppService,
            IFormAppService formAppService)
        {
            _countryContentAppService = countryContentAppService;
            _lookupAppService = lookupAppService;
            _formAppService = formAppService;
        }

        public async Task<IActionResult> OnGet(int id, bool r = false)
        {
            var data = await _countryContentAppService.GetCountryContentAsync(id);
            if (!data.Success)
                return Redirect("~/Error?httpStatusCode=404");

            CountryContent = data.Data;
            Form = new FormModel();
            Form.CountryContentId = id;
            Form.CountryId = CountryContent.CountryId;
            Genders = _lookupAppService.GetGenderLookup();
            if (r)
            {
                //Alerts.Info(L["FormRequestSuccessfully"].Value);
                Form.IsReturnPost = true;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var input = ObjectMapper.Map<FormModel, CreateUpdateFormDto>(Form);
                    var addedResult = await _formAppService.CreateAsync(input);
                    if (addedResult != null)
                    {
                        var redirectUrl = $"~/Country/Detail?id={Form.CountryContentId}&r={true}";
                        return Redirect(redirectUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Country > DetailModel > OnPostAsync has error! ");
            }

            Alerts.Danger(L["GeneralError"].Value);
            return Page();
        }

        public class FormModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [Phone]
            [StringLength(16, MinimumLength = 16, ErrorMessage = "Telefon alanı geçerli bir telefon numarası olmalıdır.")]
            public string PhoneNumber { get; set; }
            [Required]
            [SelectItems(nameof(Gender))]
            public GenderType Gender { get; set; }
            public Nullable<DateTime> BirthDate { get; set; }
            //[Required]
            //[SelectItems(nameof(Countries))]
            [HiddenInput]
            public int CountryId { get; set; }
            [TextArea(Rows = 3)]
            public string Description { get; set; }
            [HiddenInput]
            public bool IsReturnPost { get; set; } = false;
            [HiddenInput]
            public int CountryContentId { get; set; }
        }
    }
}
