using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using WorldTravel.Entities.CountryContents;
using WorldTravel.Entities.Forms;
using WorldTravel.Entities.ShareContents;

namespace WorldTravel.Entities.Countries
{
    // Share content için toplam sayı
    //CountryContent Icın toplam sayı
    //Form da seçilen ülkelerin sayısıyla ilgili bişeyler yap.
    public class Country : Entity<int>
    {
        public string Title { get; set; }

        public virtual ICollection<CountryContent> CountryContents { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
        public virtual ICollection<ShareContent> ShareContents { get; set; }

    }
}
