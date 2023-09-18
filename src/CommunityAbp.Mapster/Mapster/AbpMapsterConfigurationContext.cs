using Mapster;
using System;

namespace CommunityAbp.Mapster;

public class AbpMapsterConfigurationContext : IAbpMapsterConfigurationContext
{
    public AbpMapsterConfigurationContext(TypeAdapterConfig adapterConfig, IServiceProvider serviceProvider)
    {
        MapperConfiguration = adapterConfig;
        ServiceProvider = serviceProvider;
    }

    public TypeAdapterConfig MapperConfiguration { get; }

    public IServiceProvider ServiceProvider { get; }
}
