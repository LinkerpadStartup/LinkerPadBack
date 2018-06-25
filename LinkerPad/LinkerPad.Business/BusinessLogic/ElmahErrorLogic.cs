using System.Collections.Generic;
using System.Linq;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.DataAccess.Data;
using LinkerPad.DataAccess.Entity;
using LinkerPad.DataAccess.EntityInterface;

namespace LinkerPad.Business.BusinessLogic
{
    public class ElmahErrorLogic : IElmahErrorLogic
    {
        private readonly IElmahErrorRepository _elmahErrorRepository;

        public ElmahErrorLogic()
        {
            _elmahErrorRepository = new ElmahErrorRepository();
        }

        public IEnumerable<ElmahErrorData> GetAllElmahErrorData()
        {
            IQueryable<ELMAH_Error> elmahErrorDataSource = _elmahErrorRepository.GetAll();

            return elmahErrorDataSource.Select(ElmahErrorData.GetElmahErrorData);
        }
    }
}
