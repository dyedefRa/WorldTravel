using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WorldTravel.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<WorldTravelWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}

//Dil değiştirildiğinde home sayfasına atıyor. degısıtırcez.
//tüm imagelere Alt ve title ver.

//DIL MUHABBETINI BENI OKUYA EKLE 
//CHATBOT BENI OKUYA EKLE.

//GEREKSIZ DLLLERI CSS RESIM VS KALDIr.
//PROJE SONUNDA eng.json doldur.
