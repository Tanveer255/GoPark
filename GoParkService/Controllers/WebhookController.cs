using Microsoft.AspNetCore.Mvc;
using Stripe;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoParkService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebhookController : ControllerBase
{
    private const string endpointSecret = "your_webhook_secret";

    [HttpPost]
    public async Task<IActionResult> HandleWebhook()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], endpointSecret);

            // Ensure correct event names from Stripe
            if (stripeEvent.Type == "customer.subscription.created")
            {
                var subscription = stripeEvent.Data.Object as Subscription;
                // Handle subscription created event
            }
            else if (stripeEvent.Type == "customer.subscription.updated")
            {
                var subscription = stripeEvent.Data.Object as Subscription;
                // Handle subscription updated event
            }
            else if (stripeEvent.Type == "customer.subscription.deleted")
            {
                var subscription = stripeEvent.Data.Object as Subscription;
                // Handle subscription cancellation
            }

            return Ok();
        }
        catch (StripeException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}
