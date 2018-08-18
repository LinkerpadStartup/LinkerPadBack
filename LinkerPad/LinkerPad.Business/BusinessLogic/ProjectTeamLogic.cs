using System;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class ProjectTeamLogic : IProjectTeamLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectTeamRepository _projectTeamRepository;

        public ProjectTeamLogic(IUnitOfWork unitOfWork, IProjectTeamRepository projectTeamRepository)
        {
            _unitOfWork = unitOfWork;
            _projectTeamRepository = projectTeamRepository;
        }

        public void Add(ProjectTeamData projectTeamData)
        {
            _unitOfWork.BeginTransaction();

            _projectTeamRepository.Create(projectTeamData);

            _unitOfWork.Commit();
        }

        public bool IsUserExistInProject(string email, Guid projectId)
        {
            _unitOfWork.BeginTransaction();

           return _projectTeamRepository.GetAll()
               .Any(pt => pt.UserData.Email == email && pt.ProjectData.Id == projectId);
        }
    }
}
