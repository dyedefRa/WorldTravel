using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WorldTravel.Abstract;
using WorldTravel.Dtos.Forms;
using WorldTravel.Dtos.Jobs.ViewModels;
using WorldTravel.Enums;

namespace WorldTravel.Web.Pages.Job
{
    [AutoValidateAntiforgeryToken]
    public class DetailModel : WorldTravelPageModel
    {
        [BindProperty]
        public JobViewModel Job { get; set; }
        [BindProperty]
        public FormModel Form { get; set; }
        public List<SelectListItem> Genders { get; set; }
        public List<SelectListItem> Countries { get; set; }

        private readonly IJobAppService _jobAppService;
        private readonly ILookupAppService _lookupAppService;
        private readonly IFormAppService _formAppService;

        public DetailModel(
            IJobAppService jobAppService,
            ILookupAppService lookupAppService,
            IFormAppService formAppService)
        {
            _jobAppService = jobAppService;
            _lookupAppService = lookupAppService;
            _formAppService = formAppService;
        }

        public async Task<IActionResult> OnGet(int id, bool r = false)
        {
            var data = await _jobAppService.GetJobAsync(id);
            if (!data.Success)
                return Redirect("~/Error?httpStatusCode=404");

            Job = data.Data;
            Form = new FormModel();
            Form.JobId = id;
            Genders = _lookupAppService.GetGenderLookup();
            Countries = await _lookupAppService.GetCountryLookupAsync();
            if (r)
            {
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
                        var redirectUrl = $"~/Job/Detail?id={Form.JobId}&r={true}";
                        return Redirect(redirectUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Job > DetailModel > OnPostAsync has error! ");
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
            public int CountryId { get; set; }
            [TextArea(Rows = 3)]
            public string Description { get; set; }
            [HiddenInput]
            public bool IsReturnPost { get; set; } = false;
            [HiddenInput]
            public int JobId { get; set; }
        }
    }
}
