using System;

namespace AspNetCoreVerifiableCredentials.Models
{
    public class VerificationSession
    {
        public string SessionId { get; set; }

        public string TicketNumber { get; set; }

        public string CallerName { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }

        public DateTime CreatedUtc { get; set; }

        public DateTime? VerifiedUtc { get; set; }

        public string VerifiedUser { get; set; }

        public string Email { get; set; }

        public string JobTitle { get; set; }

        public string Photo { get; set; }

        public string CredentialType { get; set; }

        public string CredentialState { get; set; }

        public string DomainValidation { get; set; }

        public string ExpirationDate { get; set; }

        public string IssuanceDate { get; set; }
    }
}
