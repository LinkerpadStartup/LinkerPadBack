using System;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    public class ProjectLogic : IProjectLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRepository _projectRepository;

        public ProjectLogic(IUnitOfWork unitOfWork, IProjectRepository projectRepository)
        {
            _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;
        }

        public void Add(ProjectData projectData)
        {
            _unitOfWork.BeginTransaction();

            _projectRepository.Create(projectData);

            _unitOfWork.Commit();
        }
    }
}
