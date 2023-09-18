using CommunityAbp.Mapster.Tests.SampleClasses;
using Microsoft.Extensions.DependencyInjection;
using CommunityAbp.Mapster.ObjectMapping;
using NSubstitute;
using Shouldly;
using System;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace CommunityAbp.Mapster.Tests.Mapster
{
    public class CommunityAbpMapsterModule_Basic_Tests : AbpIntegratedTest<MapsterTestModule>
    {
        private readonly IObjectMapper _objectMapper;

        public CommunityAbpMapsterModule_Basic_Tests()
        {
            _objectMapper = ServiceProvider.GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public void Should_Replace_IAutoObjectMappingProvider()
        {
            Assert.True(ServiceProvider.GetRequiredService<IAutoObjectMappingProvider>() is MapsterAutoObjectMappingProvider);
        }

        [Fact]
        public void Should_Get_Internal_Mapper()
        {
            _objectMapper.GetMapper().ShouldNotBeNull();
            _objectMapper.AutoObjectMappingProvider.GetMapper().ShouldNotBeNull();
        }

        [Fact]
        public void Should_Map_Objects_With_AutoMap_Attributes()
        {
            var dto = _objectMapper.Map<MyEntity, MyEntityDto>(new MyEntity { Number = 42 });
            dto.Number.ShouldBe(42);
        }
    }
}
