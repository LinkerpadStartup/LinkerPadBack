using System;
using System.Linq;
using LinkerPad.Data;

namespace LinkerPad.Models.Account
{
    public class UserInformationViewModel
    {
        public Guid Id { get; set; }

        public UserRole? UserRole { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public string Company { get; set; }

        public static UserInformationViewModel GetUserInformationViewModel(UserData userData, ProjectData projectData = null)
        {
            return new UserInformationViewModel
            {
                Id = userData.Id,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                EmailAddress = userData.Email,
                MobileNumber = userData.MobileNumber,
                Company = userData.Company,
                ProfilePicture = userData.ProfilePicture,
                UserRole = GetUserRoleInProject(userData, projectData)
            };
        }

        protected static UserRole? GetUserRoleInProject(UserData userData, ProjectData projectData)
        {
            if (projectData == null)
                return null;

            return projectData.UserData.Id == userData.Id 
                ? Data.UserRole.Creator 
                : userData.ProjectTeamDatas.First(pt => pt.ProjectData.Id == projectData.Id).UserRole;
        }
    }
}