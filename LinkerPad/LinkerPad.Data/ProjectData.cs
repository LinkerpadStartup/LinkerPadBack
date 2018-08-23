using System;
using System.Collections.Generic;

namespace LinkerPad.Data
{
    public sealed class ProjectData
    {
        public ProjectData()
        {
            ProjectTeamDatas = new List<ProjectTeamData>();
            DailyActivityDatas = new List<DailyActivityData>();
            MaterialDatas = new List<MaterialData>();
            EquipmentDatas = new List<EquipmentData>();
        }

        public Guid Id { get; set; }

        public UserData UserData { get; set; }

        public string ProjectPicture { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }

        public int MaximunmMember { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public IList<ProjectTeamData> ProjectTeamDatas { get; set; }

        public IList<DailyActivityData> DailyActivityDatas { get; set; }

        public IList<MaterialData> MaterialDatas { get; set; }

        public IList<EquipmentData> EquipmentDatas { get; set; }
    }
}
