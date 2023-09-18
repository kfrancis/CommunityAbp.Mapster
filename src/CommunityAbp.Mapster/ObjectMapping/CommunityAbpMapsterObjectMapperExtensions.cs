using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.ObjectMapping;
using Volo.Abp;

namespace CommunityAbp.Mapster.ObjectMapping
{
    public static class CommunityAbpMapsterObjectMapperExtensions
    {
        public static IMapper GetMapper(this IObjectMapper objectMapper)
        {
            return objectMapper.AutoObjectMappingProvider.GetMapper();
        }

        public static IMapper GetMapper(this IAutoObjectMappingProvider autoObjectMappingProvider)
        {
            if (autoObjectMappingProvider is MapsterAutoObjectMappingProvider autoMapperAutoObjectMappingProvider)
            {
                return autoMapperAutoObjectMappingProvider.MapperAccessor.Mapper;
            }

            throw new AbpException($"Given object is not an instance of {typeof(MapsterAutoObjectMappingProvider).AssemblyQualifiedName}. The type of the given object it {autoObjectMappingProvider.GetType().AssemblyQualifiedName}");
        }
    }
}
