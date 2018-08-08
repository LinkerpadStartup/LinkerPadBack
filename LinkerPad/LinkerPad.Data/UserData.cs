using System;

namespace LinkerPad.Data
{
    public enum UserRole
    {
        Creator = 1,
        Collaborator = 2,
        PowerCollaborator = 3
    }

    public class UserData
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string MobileNumber { get; set; }

        public virtual string Company { get; set; }

        public virtual string ProfilePicture { get; set; }
    }
}
