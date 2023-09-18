using Volo.Abp.ObjectExtending;

namespace CommunityAbp.Mapster.Tests.SampleClasses;

public class ExtensibleTestPersonWithRegularPropertiesDto : ExtensibleObject
{
    public string Name { get; set; }

    public int Age { get; set; }

    public bool IsActive { get; set; }
}