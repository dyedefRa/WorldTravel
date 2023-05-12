using Microsoft.AspNetCore.Authorization;

namespace WorldTravel.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : WorldTravelPageModel
    {
        public void OnGet()
        {
        }
    }
}