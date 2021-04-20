using Newtonsoft.Json;

namespace Svea.Checkout.Models
{
    public class Customer
    {
        [JsonProperty("Id")]
        public long Id { get; set; }


        [JsonProperty("NationalId")]
        public string NationalId { get; set; }


        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }


        [JsonProperty("IsCompany")]
        public bool IsCompany { get; set; }
    }
}
