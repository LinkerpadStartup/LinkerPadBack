using System.Web;

namespace LinkerPad.Common
{
    public class PathManagement
    {
        #region MessageTemplate
        public static string GetMessageTemplateFile(string fileName)
        {
            return HttpContext.Current.Server.MapPath($"~/App_Data/Templates/{fileName}");
        }
        #endregion  
    }
}