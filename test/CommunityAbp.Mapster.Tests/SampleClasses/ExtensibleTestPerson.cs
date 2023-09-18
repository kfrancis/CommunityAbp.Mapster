using Volo.Abp.ObjectExtending;

namespace CommunityAbp.Mapster.Tests.SampleClasses;

public class ExtensibleTestPerson : ExtensibleObject
{
    public ExtensibleTestPerson()
    {

    }

    public ExtensibleTestPerson(bool setDefaultsForExtraProperties)
        : base(setDefaultsForExtraProperties)
    {

    }

    public void SetExtraPropertiesAsNull()
    {
        ExtraProperties = null;
    }
}
