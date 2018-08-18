using System;
namespace LinkerPad.Data
{
    public enum UserRole
    {
        Creator = 0,
        Admin = 1,
        Collaborator = 2,
        PowerCollaborator = 3
    }

    public class ProjectTeamData
    {
        public virtual Guid Id { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual UserData UserData { get; set; }

        public virtual ProjectData ProjectData { get; set; }

        public virtual DateTime CreateDate { get; set; }
    }
}
