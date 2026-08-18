using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using AspNetCoreVerifiableCredentials.Models;

namespace AspNetCoreVerifiableCredentials.Pages
{
    public class TechVerificationModel : PageModel
    {
        private readonly IMemoryCache _cache;

        public TechVerificationModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        [BindProperty]
        public string TicketNumber { get; set; }

        [BindProperty]
        public string CallerName { get; set; }

        [BindProperty]
        public string Reason { get; set; }

        public bool Started { get; set; }

        public string VerificationUrl { get; set; }

        public string SessionId { get; set; }

        public void OnGet()
        {
            Started = false;
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(TicketNumber))
            {
                ModelState.AddModelError(
                    nameof(TicketNumber),
                    "Ticket number is required.");

                Started = false;

                return Page();
            }

            TicketNumber = TicketNumber?.Trim();
            CallerName = CallerName?.Trim();
            Reason = Reason?.Trim();

            SessionId = Guid.NewGuid().ToString();

            var verificationSession = new VerificationSession
            {
                SessionId = SessionId,
                TicketNumber = TicketNumber,
                CallerName = CallerName,
                Reason = Reason,
                Status = "Pending",
                CreatedUtc = DateTime.UtcNow
            };

            _cache.Set(
                SessionId,
                verificationSession,
                TimeSpan.FromMinutes(15));

            VerificationUrl =
                $"{Request.Scheme}://{Request.Host}/verify/{SessionId}";

            Started = true;

            return Page();
        }
    }
}
