﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using WorldTravel;

namespace WorldTravel.Entities.Logs
{
    [Table(WorldTravelConsts.DbTablePrefix + "Logs")]
    public class Log : Entity<int>
    {
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
