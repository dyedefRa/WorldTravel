using System;
using WorldTravel.Enums;

namespace WorldTravel.Dtos.Forms
{
    public class CreateUpdateFormDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public GenderType Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CountryId { get; set; }
        public bool IsContacted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
