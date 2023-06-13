using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WorldTravel.Abstract;
using WorldTravel.Dtos.Forms;
using WorldTravel.Enums;

namespace WorldTravel.Web.Pages.Home
{
    [AutoValidateAntiforgeryToken]
    public class IndexModel : WorldTravelPageModel
    {
        [BindProperty]
        public FormModel FormInputModel { get; set; }
        public List<SelectListItem> Genders { get; set; }
        public List<SelectListItem> Countries { get; set; }

        private readonly ILookupAppService _lookupAppService;
        private readonly IFormAppService _formAppService;

        public IndexModel(
               ILookupAppService lookupAppService,
               IFormAppService formAppService
               )
        {
            _lookupAppService = lookupAppService;
            _formAppService = formAppService;
        }
        private async Task LoadInitializeData()
        {
            FormInputModel = new FormModel();
            Genders = _lookupAppService.GetGenderLookup();
            Countries = await _lookupAppService.GetCountryLookupAsync();
        }

        public async Task OnGet(bool r = false)
        {
            await LoadInitializeData();
            if (r)
            {
                Alerts.Info(L["FormRequestSuccessfully"].Value);
                FormInputModel.IsReturnPost = true;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var input = ObjectMapper.Map<FormModel, CreateUpdateFormDto>(FormInputModel);
                    var addedResult = await _formAppService.CreateAsync(input);
                    if (addedResult != null)
                    {
                        //return RedirectToAction("Index", "Home", new { returnPost = true });
                        var redirectUrl = $"~/Home?r={true}";
                        return Redirect(redirectUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Home > IndexModel > OnPostAsync has error! ");
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
            [Required]
            [SelectItems(nameof(Countries))]
            [DisplayName("Country")]
            public int CountryId { get; set; }
            [TextArea(Rows = 3)]
            public string Description { get; set; }
            [HiddenInput]
            public bool IsReturnPost { get; set; } = false;

        }
    }
}