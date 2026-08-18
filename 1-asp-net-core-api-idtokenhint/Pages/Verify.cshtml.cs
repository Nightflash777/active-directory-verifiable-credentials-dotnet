using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreVerifiableCredentials.Pages
{
    public class VerifyModel : PageModel
    {
        [BindProperty]
        public string SessionId { get; set; }

        public string TicketNumber { get; set; }

        public string Reason { get; set; }

        public void OnGet(string sessionId)
        {
            SessionId = sessionId;

            TicketNumber =
                HttpContext.Session.GetString("Helpdesk:TicketNumber")
                ?? "Unknown";

            Reason =
                HttpContext.Session.GetString("Helpdesk:Reason")
                ?? "Unknown";
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Verifier");
        }
    }
}
