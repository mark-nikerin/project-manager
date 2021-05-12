namespace ProjectManager.Common.ErrorResponses
{
    public class ClientErrorResponse
    {
        public ClientErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
            Success = false;
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

    }
}