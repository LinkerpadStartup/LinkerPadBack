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

        public virtual string ProfilePicture { get; set; }

        public virtual IList<ProjectData> Projects { get; set; }

        public virtual IList<ProjectTeamData> ProjectTeamDatas { get; set; }
    }
}
