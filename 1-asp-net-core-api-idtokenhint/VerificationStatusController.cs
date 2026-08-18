using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using AspNetCoreVerifiableCredentials.Models;

namespace AspNetCoreVerifiableCredentials
{
    [ApiController]
    public class VerificationStatusController : Controller
    {
        private readonly IMemoryCache _cache;

        public VerificationStatusController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet("/api/verification-status")]
        public IActionResult GetStatus(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new
                {
                    status = "Error",
                    message = "Missing id"
                });
            }

            if (!_cache.TryGetValue(
                    $"session:{id}",
                    out VerificationSession session))
            {
                return NotFound(new
                {
                    status = "NotFound"
                });
            }

            return new JsonResult(new
            {
                session.SessionId,
                session.TicketNumber,
                session.CallerName,
                session.Reason,
                session.Status,
                session.VerifiedUtc
            });
        }
    }
}
