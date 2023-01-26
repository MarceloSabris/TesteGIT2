using System.Collections.Generic;

namespace  Transacao.InfraStructure.Mediator.Model
{
    public class BusinessRuleViolatedError : Error
    {
        private const string ErrorCode = "BUSINESS_RULE_VIOLATION";
        private const string ErrorMessage = "One or more business rules were violated";

        public IEnumerable<BusinessRuleViolation> Violations { get; }

        public BusinessRuleViolatedError(params BusinessRuleViolation[] violations) : base(ErrorCode, ErrorMessage)
        {
            Violations = violations;
        }
    }
}
