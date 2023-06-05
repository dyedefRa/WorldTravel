using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WorldTravel.Enums;

namespace WorldTravel.Web.Pages.Admin.Form
{
    public class IndexModel : PageModel
    {

        public string FullNameFilter { get; set; }
        public string EmailFilter { get; set; }
        public string PhoneFilter { get; set; }
        public BooleanType IsContactedFilter { get; set; }
        public void OnGet()
        {
        }
    }
}
