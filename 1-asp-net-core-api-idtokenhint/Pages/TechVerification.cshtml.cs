using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreVerifiableCredentials.Pages
{
    public class TechVerificationModel : PageModel
    {
        [BindProperty]
        public string TicketNumber { get; set; }

        [BindProperty]
        public string CallerName { get; set; }

        [BindProperty]
        public string Reason { get; set; }

        public bool Started { get; set; }

        public void OnGet()
        {
            Started = false;
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(TicketNumber))
            {
                ModelState.AddModelError(nameof(TicketNumber), "Ticket number is required.");
                Started = false;
                return Page();
            }

            TicketNumber = TicketNumber?.Trim();
            CallerName = CallerName?.Trim();
            Reason = Reason?.Trim();

            HttpContext.Session.SetString("Helpdesk:TicketNumber", TicketNumber ?? string.Empty);
            HttpContext.Session.SetString("Helpdesk:CallerName", CallerName ?? string.Empty);
            HttpContext.Session.SetString("Helpdesk:Reason", Reason ?? string.Empty);

            Started = true;
            return Page();
        }
    }
}
