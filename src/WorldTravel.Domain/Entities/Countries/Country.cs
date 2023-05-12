using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace WorldTravel.Entities.Countries
{
    [Table(WorldTravelConsts.DbTablePrefix + "Countries")]
    public class Country : Entity<int>
    {
        [MaxLength(255)]
        public string Title { get; set; }
    }
}
