using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Confirmation
{
    public class CreateConfirmationViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        public static ConfirmationData GetConfirmationData(Guid userId, CreateConfirmationViewModel createConfirmationViewModel)
        {
            return new ConfirmationData
            {
                ProjectData = new ProjectData
                {
                    Id = createConfirmationViewModel.ProjectId
                },
                ConfirmedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = createConfirmationViewModel.ReportDate
            };
        }
    }
}