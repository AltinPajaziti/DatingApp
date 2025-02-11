namespace API.Errors
{
    public class ApiExceptions(int statuscode , string message = null, string details = null)

    {
        public int StatusCode { get; set; } = statuscode;
        public string Message { get; set; } = message;
        public string? Details { get; set; } = details;

       
    }

}
