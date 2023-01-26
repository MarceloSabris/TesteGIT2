using System;

namespace Transacao.InfraStructure.Mediator.Model
{
    public class UnexpectedError : Error
    {
        private const string ErrorCode = "UNEXPECTED_ERROR";
        private const string ErrorMessage = "An unexpected error happened";

        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }

        public UnexpectedError(Exception exception) : base(ErrorCode, ErrorMessage)
        {
            ExceptionType = exception.GetType().FullName;
            ExceptionMessage = exception.Message;
            StackTrace = exception.ToString();
        }

        public static implicit operator UnexpectedError(Exception exception)
        {
            return new UnexpectedError(exception);
        }
    }
}
