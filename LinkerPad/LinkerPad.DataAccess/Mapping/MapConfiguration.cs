﻿using FluentNHibernate.Cfg;

namespace LinkerPad.DataAccess.Mapping
{
    class MapConfiguration
    {
        public static void BindingMappedModels(MappingConfiguration mappingConfiguration)
        {
            mappingConfiguration.FluentMappings.Add<UserDataMap>();
            mappingConfiguration.FluentMappings.Add<ProjectDataMap>();
            mappingConfiguration.FluentMappings.Add<ProjectTeamDataMap>();
            mappingConfiguration.FluentMappings.Add<DailyActivityDataMap>();
            mappingConfiguration.FluentMappings.Add<MaterialDataMap>();
            mappingConfiguration.FluentMappings.Add<EquipmentDataMap>();
            mappingConfiguration.FluentMappings.Add<ConfirmationDataMap>();
            mappingConfiguration.FluentMappings.Add<NoteDataMap>();
        }
    }
}
