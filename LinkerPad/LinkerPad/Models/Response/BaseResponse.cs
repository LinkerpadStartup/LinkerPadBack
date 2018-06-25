namespace LinkerPad.Models.Response
{
    public enum ResponseStatus
    {
        ValidationError = 1,
        Notfound = 2
    }

    public class BaseResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public BaseResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}