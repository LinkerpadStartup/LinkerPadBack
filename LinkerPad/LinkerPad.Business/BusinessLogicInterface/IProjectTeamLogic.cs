using System;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IProjectTeamLogic
    {
        void Add(ProjectTeamData projectTeamData);

        bool IsUserExistInProject(string email, Guid projectId);
    }
}