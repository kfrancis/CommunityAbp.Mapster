using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;

namespace CommunityAbp.Mapster.Tests.Mapster
{
    public class Mapster_CustomServiceConstruction_Tests
    {
        [DependsOn(typeof(CommunityAbpMapsterModule))]
        public class TestModule : AbpModule
        {
            public override void ConfigureServices(ServiceConfigurationContext context)
            {
                // Replace the build-in IMapper with a custom one to use ConstructServicesUsing.
                context.Services.Replace(ServiceDescriptor.Transient<IMapper>(sp => sp.GetRequiredService<IConfigurationProvider>().CreateMapper()));

                Configure<CommunityAbpMapsterOptions>(options =>
                {
                    options.AddMaps<TestModule>();
                    options.Configurators.Add(configurationContext =>
                    {
                        configurationContext.MapperConfiguration.ConstructServicesUsing(type =>
                            type.Name.Contains(nameof(CustomMappingAction))
                                ? new CustomMappingAction(nameof(CustomMappingAction))
                                : Activator.CreateInstance(type));
                    });
                });
            }
        }

        public class SourceModel
        {
            public string Name { get; set; }
        }

        public class DestModel
        {
            public string Name { get; set; }
        }

        public class MapperActionProfile : TypeAdapterConfig
        {
            public MapperActionProfile()
            {
                TypeAdapterConfig<SourceModel, DestModel>.NewConfig().AfterMapping(x => x.Name = "AfterMapping");
            }
        }
    }
}
