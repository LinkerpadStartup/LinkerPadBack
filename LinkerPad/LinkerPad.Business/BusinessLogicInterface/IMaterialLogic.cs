using System;
using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IMaterialLogic
    {
        void Add(MaterialData materialData);

        void Edit(MaterialData materialData);

        void Delete(Guid materialId);

        MaterialData GetMaterial(Guid materialId);

        IEnumerable<MaterialData> GetProjectMaterials(Guid projectId, DateTime reportDate);

        bool IsMaterialCreatedBy(Guid currentUserId, Guid materialId);

        bool IsMaterialExist(Guid projectId, Guid materialId);
    }
}