using Volo.Abp.Domain.Entities;
using WorldTravel.Entities.Files;
using WorldTravel.Entities.ShareContents;

namespace WorldTravel.Entities.ShareContentFiles
{
    public class ShareContentFile : Entity<int>
    {
        public int ShareContentId { get; set; }
        public virtual ShareContent ShareContent { get; set; }
        public int FileId { get; set; }
        public virtual File File { get; set; }
    }
}
