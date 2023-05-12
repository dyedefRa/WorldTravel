using WorldTravel.Entities.Towns;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace WorldTravel.Entities.Cities
{
    [Table(WorldTravelConsts.DbTablePrefix + "Cities")]
    public class City : Entity<int>
    {
        [MaxLength(255)]
        public string Title { get; set; }
        public int CityNo { get; set; }
        [MaxLength(255)]
        public string AreaNumber { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
