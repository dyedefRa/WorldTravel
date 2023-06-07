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
            //myGroup.AddPermission(EvArkadasimPermissions.MyPermission1, L("Permission:MyPermission1"));

            var formPermission = myGroup.AddPermission(WorldTravelPermissions.Form.Default, L("FormManagement"));
            //formPermission.AddChild(WorldTravelPermissions.Form.Create, L("Permission:Create"));
            formPermission.AddChild(WorldTravelPermissions.Form.Edit, L("Permission:Edit"));
            //formPermission.AddChild(WorldTravelPermissions.Form.Delete, L("Permission:Delete"));
            //formPermission.AddChild(WorldTravelPermissions.Form.ManagePermissions, L("Permission:ManagePermissions"));

            var counrtyContentPermission = myGroup.AddPermission(WorldTravelPermissions.CountryContent.Default, L("CountryContentManagement"));
            counrtyContentPermission.AddChild(WorldTravelPermissions.CountryContent.Create, L("Permission:Create"));
            counrtyContentPermission.AddChild(WorldTravelPermissions.CountryContent.Edit, L("Permission:Edit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WorldTravelResource>(name);
        }
    }
}
