using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using WorldTravel.Dtos.Countries;
using WorldTravel.Entities.CountryContentFiles;
using WorldTravel.Enums;

namespace WorldTravel.Dtos.CountryContents
{
    public class CountryContentDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
        public int ReadCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidDate { get; set; }
        public Status Status { get; set; }
        public List<CountryContentFileDto> CountryContentFiles { get; set; }
    }
}
