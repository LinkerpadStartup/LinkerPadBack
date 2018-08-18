using System;
using System.ComponentModel.DataAnnotations;
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
                UserRole = UserRole.Collaborator,
                CreateDate = DateTime.Now
            };
        }
    }
}