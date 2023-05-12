using WorldTravel.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace WorldTravel.Entities.MailTemplates
{
    [Table(WorldTravelConsts.DbTablePrefix + "MailTemplates")]
    public class MailTemplate : Entity<int>
    {
        [Required]
        [MaxLength(500)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(100)]
        public string MailKey { get; set; }
        [Required]
        public string MailTemplateValue { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
