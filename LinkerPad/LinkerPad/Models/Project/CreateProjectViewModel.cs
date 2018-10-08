using System;
using System.ComponentModel.DataAnnotations;
using LinkerPad.Data;

namespace LinkerPad.Models.Project
{
    public class CreateProjectViewModel
    {
        public string ProjectPicture { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public static ProjectData GetProjectData(Guid userId, CreateProjectViewModel createProjectViewModel)
        {
            return new ProjectData
            {
                UserData = new UserData
                {
                    Id = userId
                },
                Name = createProjectViewModel.Name,
                ProjectPicture = createProjectViewModel.ProjectPicture,
                Code = createProjectViewModel.Code,
                Address = createProjectViewModel.Address,
                MaximunmMember = 2,
                StartDate = createProjectViewModel.StartDate,
                EndDate = createProjectViewModel.EndDate,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}