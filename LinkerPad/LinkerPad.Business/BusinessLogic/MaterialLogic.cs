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
    }
}
