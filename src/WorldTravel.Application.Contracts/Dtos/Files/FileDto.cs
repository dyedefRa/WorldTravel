using WorldTravel.Enums;
using Volo.Abp.Application.Dtos;

namespace WorldTravel.Dtos.Files
{
    public class FileDto : EntityDto<int>
    {
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public string FilePath { get; set; }
        public string FullPath { get; set; }
        public FileType FileType { get; set; }
        public Status Status { get; set; }

    }
}
