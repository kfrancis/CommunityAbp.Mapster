using Volo.Abp.Modularity;

namespace CommunityAbp.Mapster.Tests
{
    [DependsOn(
        typeof(CommunityAbpMapsterModule)
    )]
    public class MapsterTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<CommunityAbpMapsterOptions>(options =>
            {
                options.AddMaps<MapsterTestModule>();
            });
        }
    }
}
