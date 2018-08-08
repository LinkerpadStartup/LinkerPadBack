using FluentNHibernate.Cfg;

namespace LinkerPad.DataAccess.Mapping
{
    class MapConfiguration
    {
        public static void BindingMappedModels(MappingConfiguration mappingConfiguration)
        {
            mappingConfiguration.FluentMappings.Add<UserDataMap>();
        }
    }
}
