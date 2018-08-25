using System;
using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.Business.BusinessLogic
{
    internal class EquipmentLogic : IEquipmentLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentLogic(IUnitOfWork unitOfWork, IEquipmentRepository equipmentRepository)
        {
            _unitOfWork = unitOfWork;
            _equipmentRepository = equipmentRepository;
        }
        public void Add(EquipmentData equipmentData)
        {
            _unitOfWork.BeginTransaction();

            _equipmentRepository.Create(equipmentData);

            _unitOfWork.Commit();
        }

        public void Edit(EquipmentData equipmentData)
        {
            _unitOfWork.BeginTransaction();

            EquipmentData currentEquipmentData = _equipmentRepository.GetById(equipmentData.Id);

            currentEquipmentData.Description = equipmentData.Description;
            currentEquipmentData.Title = equipmentData.Title;
            currentEquipmentData.WorkHours = equipmentData.WorkHours;
            currentEquipmentData.NumberOfActiveEquipment = equipmentData.NumberOfActiveEquipment;
            currentEquipmentData.NumberOfDeactiveEquipment = equipmentData.NumberOfDeactiveEquipment;
            currentEquipmentData.ModifiedDate = DateTime.Now;

            _equipmentRepository.Update(currentEquipmentData);

            _unitOfWork.Commit();
        }

        public void Delete(Guid equipmentId)
        {
            _unitOfWork.BeginTransaction();

            _equipmentRepository.Delete(equipmentId);

            _unitOfWork.Commit();
        }

        public EquipmentData GetEquipment(Guid equipmentId)
        {
            return _equipmentRepository.GetById(equipmentId);
        }

        public IEnumerable<EquipmentData> GetProjectEquipment(Guid projectId, DateTime reportDate)
        {
            IQueryable<EquipmentData> equipmentDataSource = _equipmentRepository.GetAll()
                 .Where(d => d.ProjectData.Id == projectId && d.ReportDate.Date == reportDate.Date);

            return equipmentDataSource.AsEnumerable();
        }

        public bool IsEquipmentCreatedBy(Guid currentUserId, Guid equipmentId)
        {
            return _equipmentRepository.GetById(equipmentId).CreatedBy.Id == currentUserId;
        }

        public bool IsEquipmentExist(Guid projectId, Guid equipmentId)
        {
            return _equipmentRepository.GetAll().Any(d => d.ProjectData.Id == projectId && d.Id == equipmentId);
        }
    }
}
