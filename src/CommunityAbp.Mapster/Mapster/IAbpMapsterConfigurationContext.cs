using Mapster;
using System;

namespace CommunityAbp.Mapster;

public interface IAbpMapsterConfigurationContext
{
    TypeAdapterConfig MapperConfiguration { get; }

    IServiceProvider ServiceProvider { get; }
}