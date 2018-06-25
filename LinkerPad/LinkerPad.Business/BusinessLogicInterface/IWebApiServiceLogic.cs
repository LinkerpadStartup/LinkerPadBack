using System.Net;

namespace LinkerPad.Business.BusinessLogicInterface
{
    public interface IWebApiServiceLogic
    {
        string SendPostRequest(string address, string data);

        string SendGetRequest(string address);

        string ResellerSendRequest(string address, string apiKey, string data);

        string SendRequestWithHeader(string address, string data, string apiKey, out HttpStatusCode httpStatusCode);

        string CreateTinyUrl(string postUrl);
    }
}
