using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Project
{
    public class EditProjectViewModel
    {
        [Required]
        public Guid Id { get; set; }

        public string ProjectPicture { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public static ProjectData GetProjectData(EditProjectViewModel editProjectViewModel)
        {
            return new ProjectData
            {
                Id = editProjectViewModel.Id,
                ProjectPicture = editProjectViewModel.ProjectPicture,
                Name = editProjectViewModel.Name,
                Code = editProjectViewModel.Code,
                Address = editProjectViewModel.Address,
                StartDate = editProjectViewModel.StartDate,
                EndDate = editProjectViewModel.EndDate
            };
        }
    }
}