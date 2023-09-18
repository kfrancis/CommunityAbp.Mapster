using CommunityAbp.Mapster;
using Mapster;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.ObjectMapping;

namespace Microsoft.Extensions.DependencyInjection;

public static class AbpMapsterServiceCollectionExtensions
{
    public static IServiceCollection AddMapsterObjectMapper(this IServiceCollection services)
    {
        return services.Replace(
            ServiceDescriptor.Transient<IAutoObjectMappingProvider, MapsterAutoObjectMappingProvider>()
        );
    }

    public static IServiceCollection AddMapsterObjectMapper<TContext>(this IServiceCollection services)
    {
        return services.Replace(
            ServiceDescriptor.Transient<IAutoObjectMappingProvider<TContext>, MapsterAutoObjectMappingProvider<TContext>>()
        );
    }
}

public static class MapsterExtensions
{
    public static void ApplyExtraPropertiesSettings<TSource, TDestination>(
        this TypeAdapterSetter<TSource, TDestination> config,
        TypeAdapterSettings settings)
    {
        config.IgnoreNullValues(settings.IgnoreNullValues ?? false);

    }
}
