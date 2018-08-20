using System;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IProjectTeamLogic
    {
        void Add(ProjectTeamData projectTeamData);

        void Delete(ProjectTeamData projectTeamData);

        void ChangeUserRole(ProjectTeamData projectTeamData);

        bool IsUserExistInProject(string email, Guid projectId);

        bool IsUserExistInProject(Guid userId, Guid projectId);
    }
}