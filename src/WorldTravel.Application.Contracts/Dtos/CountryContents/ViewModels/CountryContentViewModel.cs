using System;

namespace WorldTravel.Dtos.CountryContents.ViewModels
{
    public class CountryContentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CountryName { get; set; }
        public string PreviewImageUrl { get; set; }
        public int ReadCount { get; set; }
        public int TotalImageCount { get; set; } = 0;
        public int TotalVideoCount { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        //public DateTime ValidDate { get; set; }
        //public Status Status { get; set; }

    }
}
