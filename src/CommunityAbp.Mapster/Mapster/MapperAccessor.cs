using MapsterMapper;

namespace CommunityAbp.Mapster;

internal class MapperAccessor : IMapperAccessor
{
    public IMapper Mapper { get; set; } = default!;
}
