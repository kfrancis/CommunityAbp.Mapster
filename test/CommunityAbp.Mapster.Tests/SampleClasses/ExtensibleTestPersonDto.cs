using Volo.Abp.ObjectExtending;

namespace CommunityAbp.Mapster.Tests.SampleClasses;

public class ExtensibleTestPersonDto : ExtensibleObject
{
    public void SetExtraPropertiesAsNull()
    {
        ExtraProperties = null;
    }
}
