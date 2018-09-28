using System;
using System.Collections.Generic;

namespace LinkerPad.Data
{
    public class UserData
    {
        public UserData()
        {
            Projects = new List<ProjectData>();
            ProjectTeamDatas = new List<ProjectTeamData>();
            DailyActivityDatas = new List<DailyActivityData>();
            ConfirmationDatas = new List<ConfirmationData>();
            EquipmentDatas = new List<EquipmentData>();
            MaterialDatas = new List<MaterialData>();
            NoteDatas = new List<NoteData>();
        }

        public virtual Guid Id { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string MobileNumber { get; set; }

        public virtual string Company { get; set; }

        public virtual string Skill { get; set; }

        public virtual string ProfilePicture { get; set; }

        public virtual IList<ProjectData> Projects { get; set; }

        public virtual IList<ProjectTeamData> ProjectTeamDatas { get; set; }

        public virtual IList<DailyActivityData> DailyActivityDatas { get; set; }

        public virtual IList<ConfirmationData> ConfirmationDatas { get; set; }

        public virtual IList<MaterialData> MaterialDatas { get; set; }

        public virtual IList<EquipmentData> EquipmentDatas { get; set; }

        public virtual IList<NoteData> NoteDatas { get; set; }


    }
}
