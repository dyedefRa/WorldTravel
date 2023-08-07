﻿using System;
using Volo.Abp.Application.Dtos;
using WorldTravel.Dtos.Countries;
using WorldTravel.Dtos.Files;
using WorldTravel.Enums;

namespace WorldTravel.Dtos.VisaTypes
{
    public class VisaTypeDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ExtraDescription { get; set; }
        public int ImageId { get; set; }
        public virtual FileDto Image { get; set; }
        public int CountryId { get; set; }
        public virtual CountryDto Country { get; set; }
        public int ReadCount { get; set; }
        public int Rank { get; set; }
        public bool IsSeenHomePage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidDate { get; set; }
        public Status Status { get; set; }
    }
}
