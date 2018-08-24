using System;
using System.Collections.Generic;

namespace LinkerPad.Data
{
    public class ProjectData
    {
        public ProjectData()
        {
            ProjectTeamDatas = new List<ProjectTeamData>();
            DailyActivityDatas = new List<DailyActivityData>();
            MaterialDatas = new List<MaterialData>();
            EquipmentDatas = new List<EquipmentData>();
            ConfirmationDatas = new List<ConfirmationData>();
        }

        public virtual Guid Id { get; set; }

        public virtual UserData UserData { get; set; }

        public virtual string ProjectPicture { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual string Address { get; set; }

        public virtual int MaximunmMember { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }

        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual IList<ProjectTeamData> ProjectTeamDatas { get; set; }

        public virtual IList<DailyActivityData> DailyActivityDatas { get; set; }

        public virtual IList<MaterialData> MaterialDatas { get; set; }

        public virtual IList<EquipmentData> EquipmentDatas { get; set; }

        public virtual IList<ConfirmationData> ConfirmationDatas { get; set; }
    }
}
