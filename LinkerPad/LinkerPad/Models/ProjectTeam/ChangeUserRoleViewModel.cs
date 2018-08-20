using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Common.CustomeValidationAttribute;
using LinkerPad.Data;

namespace LinkerPad.Models.ProjectTeam
{
    public class ChangeUserRoleViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ValidEnumValue]
        public UserRole UserRole { get; set; }

        public static ProjectTeamData GetProjectTeamData(ChangeUserRoleViewModel changeUserRoleViewModel)
        {
            return new ProjectTeamData
            {
                ProjectData = new ProjectData
                {
                    Id = changeUserRoleViewModel.ProjectId
                },
                UserData = new UserData
                {
                    Id = changeUserRoleViewModel.UserId
                },
                UserRole = changeUserRoleViewModel.UserRole
            };
        }
    }
}