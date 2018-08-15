namespace LinkerPad.Models.Response
{
    public enum ResponseStatus
    {
        Success = 0,
        ValidationError = 1,
        Notfound = 2
    }

    public class BaseResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public object ResponseObject { get; set; }

        public BaseResponse(string status, string message, object responseObject = null)
        {
            Status = status;
            Message = message;
            ResponseObject = responseObject;
        }
    }
}