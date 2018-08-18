using LinkerPad.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    internal class ProjectTeamRepository : Repository<ProjectTeamData>, IProjectTeamRepository
    {
        public ProjectTeamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
