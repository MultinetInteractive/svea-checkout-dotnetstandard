using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public class IdentityFlags
    {
        [JsonProperty("HideNotYou")]
        public bool HideNotYou { get; set; }
        [JsonProperty("HideChangeAddress")]
        public bool HideChangeAddress { get; set; }
        [JsonProperty("HideAnonymous")]
        public bool HideAnonymous { get; set; }
    }
}
