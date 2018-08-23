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
    }
}
