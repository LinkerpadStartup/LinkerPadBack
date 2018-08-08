using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Common;
using LinkerPad.Data;

namespace LinkerPad.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Company { get; set; }

        [Required]
        [RegularExpression("^[989][0-9]{11}$")]
        [MaxLength(12)]
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
                Company = registerViewModel.Company,
                Password = HashManagement.Md5Hash(registerViewModel.Password),
                CreateDate = DateTime.Now
            };
        }
    }
}