using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IEquipmentLogic
    {
        void Add(EquipmentData equipmentData);

        void Edit(EquipmentData equipmentData);

        void Delete(Guid equipmentId);

        EquipmentData GetEquipment(Guid equipmentId);

        IEnumerable<EquipmentData> GetProjectEquipment(Guid projectId, DateTime reportDate);

        bool IsEquipmentCreatedBy(Guid currentUserId, Guid equipmentId);

        bool IsEquipmentExist(Guid projectId, Guid equipmentId);
    }
}