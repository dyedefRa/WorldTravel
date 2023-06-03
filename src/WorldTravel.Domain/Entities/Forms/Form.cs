using System;
using Volo.Abp.Domain.Entities;
using WorldTravel.Entities.Countries;
using WorldTravel.Enums;

namespace WorldTravel.Entities.Forms
{
    public class Form : Entity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public bool IsContacted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }

    }
}
