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
    }
}
