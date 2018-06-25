using System;
using LinkerPad.DataAccess.Data;

namespace LinkerPad.Data
{
    public class UserData
    {
        public Guid UserId { get; set; }

        public Guid? RoleId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ConfirmCodeExpiredDate { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string Picture { get; set; }

        public string FaraUserToken { get; set; }

        public string FaraUserId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string NationalCode { get; set; }

        public string ConfirmCode { get; set; }

        public int Credit { get; set; }

        public bool IsActive { get; set; }

        public bool IsDisabled { get; set; }

        public bool FirstLogin { get; set; }

        public static Tbl_User GetUserDataSource(UserData userData)
        {
            return new Tbl_User
            {
                Id = userData.UserId,           
                Username = userData.Username,
                Password = userData.Password
            };
        }

        public static UserData GetUserData(Tbl_User userDataSource)
        {
            return new UserData
            {
                UserId = userDataSource.Id,
                Username = userDataSource.Username,
                Password = userDataSource.Password
            };
        }
    }
}
