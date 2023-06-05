using System;
using Volo.Abp.Application.Dtos;
using WorldTravel.Dtos.Countries;
using WorldTravel.Enums;

namespace WorldTravel.Dtos.Forms
{
    public class FormDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
        public bool IsContacted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
    }
}
