namespace WorldTravel.Permissions
{
    public static class WorldTravelPermissions
    {
        public const string GroupName = "WorldTravel";
        public const string Identity = "AbpIdentity";

        public static class User
        {
            public const string Default = Identity + ".Users";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ManagePermission = Default + ".ManagePermissions";
        }

        public static class Role
        {
            public const string Default = Identity + ".Roles";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ManagePermission = Default + ".ManagePermissions";
        }

        public static class Form
        {
            public const string Default = Identity + ".Forms";
            public const string Edit = Default + ".Edit";
        }

        public static class CountryContent
        {
            public const string Default = Identity + ".CountryContents";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
        }

        public static class VisaType
        {
            public const string Default = Identity + ".VisaTypes";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
        }

        public static class Job
        {
            public const string Default = Identity + ".Jobs";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
        }

    }
}