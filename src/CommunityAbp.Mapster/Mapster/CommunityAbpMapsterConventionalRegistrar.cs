using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace CommunityAbp.Mapster;

public class CommunityAbpMapsterConventionalRegistrar : DefaultConventionalRegistrar
{
    protected readonly Type[] OpenTypes = {
        // List types here that would act as custom converters, resolvers etc. in Mapster
    };

    protected override bool IsConventionalRegistrationDisabled(Type type)
    {
        return !type.GetInterfaces().Any(x => x.IsGenericType && OpenTypes.Contains(x.GetGenericTypeDefinition())) ||
               base.IsConventionalRegistrationDisabled(type);
    }

    protected override ServiceLifetime? GetDefaultLifeTimeOrNull(Type type)
    {
        return ServiceLifetime.Transient;
    }
}