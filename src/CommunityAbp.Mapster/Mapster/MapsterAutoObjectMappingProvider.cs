using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.ObjectMapping;

namespace CommunityAbp.Mapster
{
    public class MapsterAutoObjectMappingProvider<TContext> : MapsterAutoObjectMappingProvider, IAutoObjectMappingProvider<TContext>
    {
        public MapsterAutoObjectMappingProvider(IMapperAccessor mapperAccessor)
            : base(mapperAccessor)
        {
        }
    }

    public class MapsterAutoObjectMappingProvider : IAutoObjectMappingProvider
    {
        public IMapperAccessor MapperAccessor { get; }

        public MapsterAutoObjectMappingProvider(IMapperAccessor mapperAccessor)
        {
            MapperAccessor = mapperAccessor;
        }

        public virtual TDestination Map<TSource, TDestination>(object source)
        {
            return MapperAccessor.Mapper.Map<TDestination>(source);
        }

        public virtual TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return MapperAccessor.Mapper.Map(source, destination);
        }
    }
}
