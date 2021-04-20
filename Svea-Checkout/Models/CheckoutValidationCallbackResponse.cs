using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public class CheckoutValidationCallbackResponse
    {
        [JsonProperty("Valid")]
        public bool Valid { get; set; }

        [JsonProperty("ClientOrderNumber")]
        public string ClientOrderNumber { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
