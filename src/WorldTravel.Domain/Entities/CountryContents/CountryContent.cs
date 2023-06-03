using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using WorldTravel.Entities.Countries;
using WorldTravel.Entities.CountryContentFiles;
using WorldTravel.Enums;

namespace WorldTravel.Entities.CountryContents
{
    public class CountryContent : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int ReadCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidDate { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<CountryContentFile> CountryContentFiles { get; set; }

        //YORUM MUHABBETINI SONRA YAPCAZ
    }
}
