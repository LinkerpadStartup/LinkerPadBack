using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class MaterialRepository : Repository<MaterialData>, IMaterialRepository
    {
        public MaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
