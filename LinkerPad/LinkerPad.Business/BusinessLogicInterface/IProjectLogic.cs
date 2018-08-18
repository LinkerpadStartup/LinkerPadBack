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

        UserRole GetUserRoleInProject(Guid userId, Guid projectId);

        bool IsUserAdminOrCreatorOfProject(Guid userId, Guid projectId);

        bool IsUserProjectCreator(Guid userId, Guid projectId);

        bool IsProjectExist(Guid userId, Guid projectId);
    }
}