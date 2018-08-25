using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class MaterialLogic : IMaterialLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialRepository _materialRepository;

        public MaterialLogic(IUnitOfWork unitOfWork, IMaterialRepository materialRepository)
        {
            _unitOfWork = unitOfWork;
            _materialRepository = materialRepository;
        }
        public void Add(MaterialData materialData)
        {
            _unitOfWork.BeginTransaction();

            _materialRepository.Create(materialData);

            _unitOfWork.Commit();
        }

        public void Edit(MaterialData materialData)
        {
            _unitOfWork.BeginTransaction();

            MaterialData currentMaterialData = _materialRepository.GetById(materialData.Id);

            currentMaterialData.Description = materialData.Description;
            currentMaterialData.Title = materialData.Title;
            currentMaterialData.ConsumedQuantity = materialData.ConsumedQuantity;
            currentMaterialData.ConsumedQuantityUnit = materialData.ConsumedQuantityUnit;
            currentMaterialData.ModifiedDate = DateTime.Now;

            _materialRepository.Update(currentMaterialData);

            _unitOfWork.Commit();
        }

        public void Delete(Guid materialId)
        {
            _unitOfWork.BeginTransaction();

            _materialRepository.Delete(materialId);

            _unitOfWork.Commit();
        }

        public MaterialData GetMaterial(Guid materialId)
        {
            return _materialRepository.GetById(materialId);
        }

        public IEnumerable<MaterialData> GetProjectMaterials(Guid projectId, DateTime reportDate)
        {
            IQueryable<MaterialData> materialsDataSource = _materialRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return materialsDataSource.AsEnumerable();
        }

        public bool IsMaterialCreatedBy(Guid currentUserId, Guid materialId)
        {
            return _materialRepository.GetById(materialId).CreatedBy.Id == currentUserId;
        }

        public bool IsMaterialExist(Guid projectId, Guid materialId)
        {
            return _materialRepository.GetAll().Any(d => d.ProjectData.Id == projectId && d.Id == materialId);
        }
    }
}
