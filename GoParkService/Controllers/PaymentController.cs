using GoParkService.Entity.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe.Checkout;
using Stripe;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoParkService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly StripeSettings _stripeSettings;

        public PaymentController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] SubscriptionRequest request)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = request.Amount,  // Price in cents (e.g., 1000 = $10.00)
                        Currency = "usd",
                        Recurring = new SessionLineItemPriceDataRecurringOptions
                        {
                            Interval = "month" // Can be "day", "week", "month", "year"
                        },
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.PlanName
                        }
                    },
                    Quantity = 1,
                }
            },
                Mode = "subscription",
                SuccessUrl = $"{request.SuccessUrl}?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = request.CancelUrl
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return Ok(new { sessionId = session.Id });
        }

        [HttpGet("retrieve-session/{sessionId}")]
        public async Task<IActionResult> RetrieveSession(string sessionId)
        {
            var service = new SessionService();
            var session = await service.GetAsync(sessionId);

            return Ok(session);
        }
    }
}
public class SubscriptionRequest
{
    public string PlanName { get; set; }
    public long Amount { get; set; }
    public string SuccessUrl { get; set; }
    public string CancelUrl { get; set; }
}