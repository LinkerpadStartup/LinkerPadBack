using System;

namespace LinkerPad.Models.UserInfo
{
    public class CurrentUserInfo
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string FaraUserToken { get; set; }
        public string FaraUserId { get; set; }
    }
}