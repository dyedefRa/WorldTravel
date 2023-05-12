using WorldTravel.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WorldTravel.Permissions
{
    public class WorldTravelPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(WorldTravelPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(WorldTravelPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WorldTravelResource>(name);
        }
    }
}
