using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using AspNetCoreVerifiableCredentials.Models;

namespace AspNetCoreVerifiableCredentials.Pages
{
    public class VerifyModel : PageModel
    {
        private readonly IMemoryCache _cache;

        public VerifyModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string SessionId { get; set; }

        public string TicketNumber { get; set; }

        public string CallerName { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }

        public IActionResult OnGet(string sessionId)
        {
            SessionId = sessionId;

            if (!_cache.TryGetValue(sessionId, out VerificationSession session))
            {
                return RedirectToPage("/Error");
            }

            TicketNumber = session.TicketNumber;
            CallerName = session.CallerName;
            Reason = session.Reason;
            Status = session.Status;

            return Page();
        }

        public IActionResult OnPost(string sessionId)
        {
            return Redirect($"/Verifier?sessionId={sessionId}");
        }
    }
}
