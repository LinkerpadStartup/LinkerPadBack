using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Account
{
    public class EditUserViewModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        [RegularExpression("^[989][0-9]{11}$")]
        [MaxLength(12)]
        [MinLength(12)]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string Company { get; set; }

        public static UserData GetUserData(Guid userId, EditUserViewModel editUserViewModel)
        {
            return new UserData
            {
                Id = userId,
                FirstName = editUserViewModel.FirstName,
                LastName = editUserViewModel.LastName,
                MobileNumber = editUserViewModel.MobileNumber,
                Company = editUserViewModel.Company,
                ProfilePicture = editUserViewModel.ProfilePicture
            };
        }
    }
}