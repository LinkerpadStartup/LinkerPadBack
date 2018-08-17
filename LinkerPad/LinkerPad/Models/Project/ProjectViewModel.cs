using System;
using LinkerPad.Data;

namespace LinkerPad.Models.Project
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string ProjectPicture { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }

        public int MaximunmMember { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public static ProjectViewModel GetProjectViewModel(ProjectData projectData)
        {
            return new ProjectViewModel
            {
                Id = projectData.Id,
                ProjectPicture = projectData.ProjectPicture,
                Name = projectData.Name,
                Code = projectData.Code,
                Address = projectData.Address,
                MaximunmMember = projectData.MaximunmMember,
                CreateDate = projectData.CreateDate,
                StartDate = projectData.StartDate,
                EndDate = projectData.EndDate
            };
        }
    }
}