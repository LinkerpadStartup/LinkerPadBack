using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IProjectLogic
    {
        void Add(ProjectData projectData);

        void Edit(ProjectData projectData);

        IEnumerable<ProjectData> GetUserProjects(Guid userId);

        ProjectData GetProjectData(Guid projectId);

        bool IsUserProjectOwner(Guid userId, Guid projectId);

        bool IsProjectExist(Guid userId, Guid projectId);
    }
}