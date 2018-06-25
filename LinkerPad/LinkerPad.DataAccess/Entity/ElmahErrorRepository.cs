using LinkerPad.DataAccess.Data;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;

namespace LinkerPad.DataAccess.Entity
{
    public class ElmahErrorRepository : GenericRepository<LinkerPadDb, ELMAH_Error>, IElmahErrorRepository
    {
    }
}
