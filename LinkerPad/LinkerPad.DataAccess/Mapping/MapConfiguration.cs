using FluentNHibernate.Cfg;

namespace LinkerPad.DataAccess.Mapping
{
    class MapConfiguration
    {
        public static void BindingMappedModels(MappingConfiguration mappingConfiguration)
        {
            mappingConfiguration.FluentMappings.Add<UserDataMap>();
            mappingConfiguration.FluentMappings.Add<ProjectDataMap>();
            mappingConfiguration.FluentMappings.Add<ProductTeamDataMap>();
        }
    }
}
