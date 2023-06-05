using System.ComponentModel;

namespace WorldTravel.Enums
{
    public enum UploadType
    {
        [Description("profile")]
        Profile = 1,
        [Description("countrycontent")]
        CountryContent = 1,
        [Description("sharecontent")]
        ShareContent = 2,
    }
}
