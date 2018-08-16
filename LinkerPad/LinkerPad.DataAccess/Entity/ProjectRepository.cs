using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class ProjectRepository : Repository<ProjectData>, IProjectRepository
    {
        public ProjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
