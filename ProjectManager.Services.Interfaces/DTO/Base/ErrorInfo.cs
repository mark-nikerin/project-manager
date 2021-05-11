namespace ProjectManager.Services.Interfaces.DTO.Base
{
    public class ErrorInfo<TEnum> where TEnum : System.Enum
    {
        public TEnum ErrorType { get; set; }

        public string ErrorMessage { get; set; }
    }
}