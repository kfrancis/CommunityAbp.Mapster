using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Collections;

namespace CommunityAbp.Mapster
{
    public class CommunityAbpMapsterOptions
    {
        public List<Action<IAbpMapsterConfigurationContext>> Configurators { get; }

        public ITypeList<TypeAdapterConfig> ValidatingProfiles { get; set; }

        public CommunityAbpMapsterOptions()
        {
            Configurators = new List<Action<IAbpMapsterConfigurationContext>>();
            ValidatingProfiles = new TypeList<TypeAdapterConfig>();
        }

        public void AddMaps<TModule>(bool validate = false)
        {
            var assembly = typeof(TModule).Assembly;

            Configurators.Add(context =>
            {
                context.MapperConfiguration.Adapt(assembly);
            });

            if (validate)
            {
                var profileTypes = assembly
                    .DefinedTypes
                    .Where(type => typeof(TypeAdapterConfig).IsAssignableFrom(type) && !type.IsAbstract && !type.IsGenericType);

                foreach (var profileType in profileTypes)
                {
                    ValidatingProfiles.Add(profileType);
                }
            }
        }

        public void AddProfile<TProfile>(bool validate = false)
            where TProfile : TypeAdapterConfig, new()
        {
            Configurators.Add(context =>
            {
                context.MapperConfiguration.Adapt<TProfile>();
            });

            if (validate)
            {
                ValidateProfile(typeof(TProfile));
            }
        }

        public void ValidateProfile<TProfile>(bool validate = true)
            where TProfile : TypeAdapterConfig
        {
            ValidateProfile(typeof(TProfile), validate);
        }

        public void ValidateProfile(Type profileType, bool validate = true)
        {
            if (validate)
            {
                ValidatingProfiles.AddIfNotContains(profileType);
            }
            else
            {
                ValidatingProfiles.Remove(profileType);
            }
        }
    }
}
