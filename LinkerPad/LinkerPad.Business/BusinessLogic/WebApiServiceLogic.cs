using System;
using System.IO;
using System.Net;
using System.Text;
using LinkerPad.Business.BusinessLogicInterface;

namespace LinkerPad.Business.BusinessLogic
{
    internal class WebApiServiceLogic : IWebApiServiceLogic
    {
        public string SendPostRequest(string address, string data)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";

                byte[] result = client.UploadData(address, "POST", Encoding.UTF8.GetBytes(data));
                return Encoding.UTF8.GetString(result);
            }
        }

        public string ResellerSendRequest(string address, string apiKey, string data)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                client.Headers["X-ApiKey"] = apiKey;

                byte[] result = client.UploadData(address, "POST", Encoding.UTF8.GetBytes(data));

                return Encoding.UTF8.GetString(result);
            }
        }

        public string SendRequestWithHeader(string address, string data, string apiKey, out HttpStatusCode httpStatusCode)
        {
            const string contentType = "application/json; charset=UTF-8";
            ServicePointManager.Expect100Continue = false;
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest webRequest = WebRequest.CreateHttp(address);
            webRequest.Method = "POST";
            webRequest.Headers["Authorization"] = apiKey;
            webRequest.ContentType = contentType;
            webRequest.CookieContainer = cookies;
            webRequest.ContentLength = data.Length;

            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(data);
            requestWriter.Close();

            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            httpStatusCode = response.StatusCode;

            responseReader.Close();
            webRequest.GetResponse().Close();

            return responseData;

        }

        public string SendGetRequest(string address)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";

                byte[] result = client.DownloadData(address);
                return Encoding.UTF8.GetString(result);
            }
        }

        public string CreateTinyUrl(string postUrl)
        {
            Uri address = new Uri($"http://tinyurl.com/api-create.php?url={postUrl}");
            WebClient client = new WebClient();
            return client.DownloadString(address);
        }
    }
}
