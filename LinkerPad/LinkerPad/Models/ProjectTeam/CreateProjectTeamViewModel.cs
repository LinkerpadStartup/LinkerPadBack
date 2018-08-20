using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Common.CustomeValidationAttribute;
using LinkerPad.Data;

namespace LinkerPad.Models.ProjectTeam
{
    public class CreateProjectTeamViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [ValidEnumValue]
        public UserRole UserRole { get; set; }

        public static ProjectTeamData GetProjectTeamData(Guid userId, CreateProjectTeamViewModel createProjectTeamViewModel)
        {
            return new ProjectTeamData
            {
                UserData = new UserData
                {
                    Id = userId
                },
                ProjectData = new ProjectData
                {
                    Id = createProjectTeamViewModel.ProjectId
                },
                UserRole = createProjectTeamViewModel.UserRole,
                CreateDate = DateTime.Now
            };
        }
    }
}