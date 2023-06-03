using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using WorldTravel.Entities.Countries;
using WorldTravel.Entities.ShareContentFiles;
using WorldTravel.Enums;

namespace WorldTravel.Entities.ShareContents
{
    //KULLANICILARDAN GELEN VIDEO VE RESIMLERI EKLYIOZ.
    public class ShareContent : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int ReadCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidDate { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<ShareContentFile> ShareContentFiles { get; set; }
    }


}
