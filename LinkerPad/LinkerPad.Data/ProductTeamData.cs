using System;
using System.Collections.Generic;

namespace LinkerPad.Data
{
    public enum UserRole
    {
        Admin = 1,
        Collaborator = 2,
        PowerCollaborator = 3
    }

    public class UserProductData
    {
        public virtual Guid Id { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual UserData UserData { get; set; }

        public virtual ProjectData ProjectData { get; set; }
    }
}
