using LinkerPad.Data;

namespace LinkerPad.Models.Account
{
    public class UserInformationViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public string EmailAddress { get; set; }

        public static UserInformationViewModel GetUserInformationViewModel(UserData userData)
        {
            return new UserInformationViewModel
            {
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                ProfilePicture = userData.ProfilePicture
            };
        }
    }
}