using System.Collections.Generic;
using LinkerPad.Data;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IElmahErrorLogic
    {
        IEnumerable<ElmahErrorData> GetAllElmahErrorData();
    }
}