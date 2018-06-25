using System.Web.Http.ExceptionHandling;

namespace LinkerPad.Common.ExceptionHandling
{
    public class ExceptionManagerLogger: ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}