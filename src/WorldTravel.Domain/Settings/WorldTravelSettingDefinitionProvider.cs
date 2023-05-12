using Volo.Abp.Settings;

namespace WorldTravel.Settings
{
    public class WorldTravelSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(WorldTravelSettings.MySetting1));
        }
    }
}
