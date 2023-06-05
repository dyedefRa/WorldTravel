using System;
using WorldTravel.Enums;

namespace WorldTravel.Dtos.Forms.ViewModels
{
    public class FormViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public GenderType Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CountryName { get; set; }
        public bool IsContacted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
