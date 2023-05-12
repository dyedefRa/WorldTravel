namespace WorldTravel.Permissions
{
    public static class WorldTravelPermissions
    {
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

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

        public static class Message
        {
            public const string Default = GroupName + ".Messages";
            public const string See = Default + ".See";
            //public const string Create = Default + ".Create";
            //public const string Edit = Default + ".Edit";
            //public const string Delete = Default + ".Delete";
        }

    }
}