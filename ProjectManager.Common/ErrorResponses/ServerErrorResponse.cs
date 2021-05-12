namespace ProjectManager.Common.ErrorResponses
{
    public class ServerErrorResponse : ClientErrorResponse
    {
        public ServerErrorResponse(string code, string message, string stackTrace)
            : base(code, message)
        {
            StackTrace = stackTrace;
        }

        public string StackTrace { get; set; }
    }
}