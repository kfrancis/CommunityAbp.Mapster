using MapsterMapper;

namespace CommunityAbp.Mapster;

public interface IMapperAccessor
{
    IMapper Mapper { get; }
}