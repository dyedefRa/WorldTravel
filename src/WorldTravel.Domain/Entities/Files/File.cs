using WorldTravel.Entities.Users;
using WorldTravel.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using WorldTravel;

namespace WorldTravel.Entities.Files
{
    [Table(WorldTravelConsts.DbTablePrefix + "Files")]
    public class File : Entity<int>
    {
        [Required]
        [MaxLength(500)]
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }
        [Required]
        [MaxLength(500)]
        public string FullPath { get; set; }
        public FileType FileType { get; set; }
        public Status Status { get; set; }
        //public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual AppUser User { get; set; }

    }
}
