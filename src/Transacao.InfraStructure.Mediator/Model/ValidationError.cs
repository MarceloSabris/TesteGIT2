using System.Collections.Generic;

namespace Transacao.InfraStructure.Mediator.Model
{
    public class ValidationError : Error
    {
        private const string ErrorCode = "VALIDATION_ERROR";
        private const string ErrorMessage = "One or more values were invalid";

        public IEnumerable<ValidationErrorDetail> Details { get; }

        public ValidationError(params ValidationErrorDetail[] details) : base(ErrorCode, ErrorMessage)
        {
            Details = details;
        }
    }
}
