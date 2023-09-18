using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommunityAbp.Mapster.Tests.Mapster
{
    public class ObjectMapperExtensions_Tests : AbpIntegratedTest<ObjectMapperExtensions_Tests.TestModule>
    {
        private readonly IObjectMapper _objectMapper;

        public ObjectMapperExtensions_Tests()
        {
            _objectMapper = ServiceProvider.GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public void Should_Validate_Configuration()
        {
            _objectMapper.Map<MySourceClass, MyClassValidated>(new MySourceClass { Value = "42" }).Value.ShouldBe("42");
            _objectMapper.Map<MySourceClass, MyClassNonValidated>(new MySourceClass { Value = "42" }).ValueNotMatched.ShouldBe(null);
        }

        [DependsOn(typeof(CommunityAbpMapsterModule))]
        public class TestModule : AbpModule
        {
            public override void ConfigureServices(ServiceConfigurationContext context)
            {
                Configure<CommunityAbpMapsterOptions>(options =>
                {
                    options.AddMaps<TestModule>(validate: true); //Adds all profiles in the TestModule assembly by validating configurations
                    options.ValidateProfile<NonValidatedProfile>(validate: false); //Exclude a profile from the configuration validation
                });
            }
        }

        public class ValidatedProfile : TypeAdapterConfig
        {
            public ValidatedProfile()
            {
                TypeAdapterConfig<MySourceClass, MyClassValidated>.NewConfig().TwoWays();
            }
        }

        public class NonValidatedProfile : TypeAdapterConfig
        {
            public NonValidatedProfile()
            {
                TypeAdapterConfig<MySourceClass, MyClassNonValidated>.NewConfig().TwoWays();
            }
        }

        public class MySourceClass
        {
            public string Value { get; set; }
        }

        public class MyClassValidated
        {
            public string Value { get; set; }
        }

        public class MyClassNonValidated
        {
            public string ValueNotMatched { get; set; }
        }
    }
}
