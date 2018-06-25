using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[09][0-9]{10}$")]
        [MaxLength(11)]
        public string MobileNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public static UserData GetUserData(RegisterViewModel registerViewModel)
        {
            return new UserData
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.EmailAddress,
                MobileNumber = registerViewModel.MobileNumber,
                Credit = 0,
                Username = registerViewModel.MobileNumber,
                Password = null,
                UserId = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                IsActive = false,
                IsDisabled = false,
                RoleId = Guid.Parse("6803662f-d2f1-460f-b974-9c33281a51a5")
            };
        }
    }
}