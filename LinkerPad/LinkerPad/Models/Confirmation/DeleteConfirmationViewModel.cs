using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Confirmation
{
    public class DeleteConfirmationViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        public static ConfirmationData GetConfirmationData(Guid userId, DeleteConfirmationViewModel deleteConfirmationViewModel)
        {
            return new ConfirmationData
            {
                ProjectData =new ProjectData
                {
                    Id = deleteConfirmationViewModel.ProjectId
                },
                ConfirmedBy = new UserData
                {
                    Id = userId
                },
                ReportDate = deleteConfirmationViewModel.ReportDate
            };
        }
    }
}