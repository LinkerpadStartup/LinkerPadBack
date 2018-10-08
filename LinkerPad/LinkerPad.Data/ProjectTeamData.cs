using System;
namespace LinkerPad.Data
{
    public enum UserRole
    {
        Creator = 0, //masul
        Admin = 1, //modir
        PowerCollaborator = 2, //sarparast
        Collaborator = 3 //karshenas
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
