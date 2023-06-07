using System;
using WorldTravel.Enums;

namespace WorldTravel.Dtos.CountryContents
{
    public class CreateUpdateCountryContentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public int ReadCount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        //şimdilik burasını boyle atayalım.
        public DateTime ValidDate { get; set; } = DateTime.MaxValue;
        public Status Status { get; set; } = Status.Active;
        //public List<CountryContentFileDto> CountryContentFiles { get; set; }
    }
}
