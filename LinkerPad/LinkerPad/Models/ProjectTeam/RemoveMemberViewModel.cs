using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.ProjectTeam
{
    public class RemoveMemberViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public static ProjectTeamData GetProjectTeamData(RemoveMemberViewModel removeMemberViewModel)
        {
            return new ProjectTeamData
            {
                ProjectData = new ProjectData
                {
                    Id = removeMemberViewModel.ProjectId
                },
                UserData = new UserData
                {
                    Id = removeMemberViewModel.UserId
                }
            };
        }
    }
}