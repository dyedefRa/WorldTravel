using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace WorldTravel.Pages
{
    public class Index_Tests : WorldTravelWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
