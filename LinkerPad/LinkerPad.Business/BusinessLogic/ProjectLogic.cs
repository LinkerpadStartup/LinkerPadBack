using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class ProjectLogic : IProjectLogic
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

        public void Edit(ProjectData projectData)
        {
            _unitOfWork.BeginTransaction();

            ProjectData currentProjectData = _projectRepository.GetById(projectData.Id);

            currentProjectData.ProjectPicture = projectData.ProjectPicture;
            currentProjectData.Name = projectData.Name;
            currentProjectData.Code = projectData.Code;
            currentProjectData.Address = projectData.Address;
            currentProjectData.StartDate = projectData.StartDate;
            currentProjectData.EndDate = projectData.EndDate;
            currentProjectData.ModifiedDate = DateTime.Now;

            _projectRepository.Update(currentProjectData);

            _unitOfWork.Commit();
        }

        public IEnumerable<ProjectData> GetUserProjects(Guid userId)
        {
            _unitOfWork.BeginTransaction();

            IQueryable<ProjectData> projectDatasDataSource =
                _projectRepository.GetAll()
                    .Where(p =>
                    p.UserData.Id == userId
                    || p.ProjectTeamDatas.Any(pt => pt.UserData.Id == userId));

            return projectDatasDataSource.AsEnumerable();
        }

        public ProjectData GetProjectData(Guid projectId)
        {
            return _projectRepository.GetById(projectId);
        }

        public UserRole GetUserRoleInProject(Guid userId, Guid projectId)
        {
            ProjectData projectData = _projectRepository.GetById(projectId);
            if (projectData.UserData.Id == userId)
                return UserRole.Admin;

            return projectData.ProjectTeamDatas
                .First(pt => pt.UserData.Id == userId && pt.ProjectData.Id == projectId).UserRole;
        }

        public bool IsUserAdminOrCreatorOfProject(Guid userId, Guid projectId)
        {
            ProjectData projectData = _projectRepository.GetById(projectId);
            if (projectData.UserData.Id == userId)
                return true;

            return projectData.ProjectTeamDatas
                       .First(pt => pt.UserData.Id == userId && pt.ProjectData.Id == projectId).UserRole == UserRole.Admin;
        }

        public bool IsUserProjectCreator(Guid userId, Guid projectId)
        {
            return _projectRepository.GetAll().Any(p => p.UserData.Id == userId && p.Id == projectId);
        }

        public bool IsProjectExist(Guid userId, Guid projectId)
        {
            return _projectRepository.GetAll()
                .Any(p =>
                p.UserData.Id == userId && p.Id == projectId
                || p.ProjectTeamDatas.Any(pt => pt.UserData.Id == userId));
        }
    }
}
