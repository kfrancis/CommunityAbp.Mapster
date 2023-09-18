using Mapster;
using System;
using System.Linq.Expressions;
using Volo.Abp.Auditing;

namespace CommunityAbp.Mapster;

public interface IMapsterConfigurationWrapper
{
    TypeAdapterConfig Config { get; }
    void ApplyConfig<TSource, TDestination>();
}

public static class MapsterExpressionExtensions
{
    public static void Ignore<TDestination, TSource, TResult>(
        this IMapsterConfigurationWrapper wrapper,
        Expression<Func<TDestination, object>> destinationMember)
    {
        wrapper.Config.NewConfig<TSource, TDestination>().Ignore(destinationMember);
    }

    public static void IgnoreHasCreationTimeProperties<TSource, TDestination>(
        this IMapsterConfigurationWrapper wrapper)
        where TDestination : IHasCreationTime
    {
        wrapper.Config.NewConfig<TSource, TDestination>().Ignore(dest => dest.CreationTime);
    }

    public static void ConstructServicesUsing<TSource, TDestination>(
           this IMapsterConfigurationWrapper wrapper,
                  Func<Type, object> factory)
        where TSource : new()
        where TDestination : new()
    {
        // Use Mapster's Compile method to compile a mapping function
        // and inject custom services into the mapper
        var config = wrapper.Config.NewConfig<TSource, TDestination>();
        config.Settings.ConstructUsingFactory = arg => {
            
            // Here, you could call your globally accessible or injected factory
            // and create an Expression that represents it.
            var factoryCall = Expression.Call(
                Expression.Constant(factory.Target), // assuming factory is a method on an object
                factory.Method,
                Expression.Constant(arg.DestinationType)
            );

            return Expression.Lambda<Func<object>>(factoryCall);
        };
    }

    // ... other similar methods
}
