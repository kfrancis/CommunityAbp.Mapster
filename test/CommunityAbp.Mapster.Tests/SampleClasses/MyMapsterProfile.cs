using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityAbp.Mapster.Tests.SampleClasses;

public class MyMapsterProfile
{

    public MyMapsterProfile()
    {
    }

    public void Build()
    {
        TypeAdapterConfig<MyEntity, MyEntityDto>.NewConfig()
           .TwoWays();

        TypeAdapterConfig<ExtensibleTestPerson, ExtensibleTestPersonDto>.NewConfig()
            .ApplyExtraPropertiesSettings(new MyExtraPropertySettings { IgnoredProperties = new[] { "CityName" } });

        TypeAdapterConfig<ExtensibleTestPerson, ExtensibleTestPersonWithRegularPropertiesDto>.NewConfig()
            .Ignore(dest => dest.Name)
            .Ignore(dest => dest.Age)
            .Ignore(dest => dest.IsActive)
            .ApplyExtraPropertiesSettings(new MyExtraPropertySettings { MapToRegularProperties = true });
    }
}
public class MyExtraPropertySettings : TypeAdapterSettings
{
    public string[]? IgnoredProperties { get; set; }
    public bool MapToRegularProperties { get; set; }
}
